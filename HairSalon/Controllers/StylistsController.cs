using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    private readonly HairSalonContext _db;

    public StylistsController(HairSalonContext db)
    {
      _db =db;
    }

    public ActionResult Index()
    {
      List<Stylist> model = _db.Stylists.ToList();
      model.Sort((x, y) => string.Compare(x.Name, y.Name));
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
      try
      {
        if (String.IsNullOrWhiteSpace(stylist.Name) || String.IsNullOrWhiteSpace(stylist.Specialty))
        {
          throw new System.InvalidOperationException("Invalid input");
        }
        else
        {
          _db.Stylists.Add(stylist);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
      }
      catch (Exception ex)
      {
        return View("Error", ex.Message);
      }
    }

    public ActionResult Details(int id)
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      thisStylist.Clients = _db.Clients.Where(client => client.StylistId == id).ToList();
      thisStylist.Appointments = _db.Appointments.Where(appointment => appointment.Stylist.Name == thisStylist.Name).ToList();
      return View(thisStylist);
    }

    public ActionResult Edit(int id)
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      return View(thisStylist);
    }

    [HttpPost]
    public ActionResult Edit(Stylist stylist)
    {
      try
      {
        if (String.IsNullOrWhiteSpace(stylist.Name) || String.IsNullOrWhiteSpace(stylist.Specialty))
        {
          throw new System.InvalidOperationException("Invalid input");
        }
        else
        {
          _db.Entry(stylist).State = EntityState.Modified;
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
      }
      catch (Exception ex)
      {
        return View("Error", ex.Message);
      }
    }

    public ActionResult Delete(int id)
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      return View(thisStylist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      thisStylist.Clients = _db.Clients.Where(client => client.StylistId == id).ToList();
      foreach(Client client in thisStylist.Clients)
      {
        _db.Clients.Remove(client);
      }
      _db.Stylists.Remove(thisStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}