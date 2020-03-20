using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly HairSalonContext _db;

    public ClientsController(HairSalonContext db)
    {
      _db = db;
    } 

    public ActionResult Index()
    {
      List<Client> model = _db.Clients.ToList();
      model.Sort((x, y) => string.Compare(x.Name, y.Name));
      return View(model);
    }

    public ActionResult Create()
    {
      try
      {
        List<Stylist> stylists = _db.Stylists.ToList();
        if (stylists.Count >= 1)
        {
          ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
          return View();
        }
        else
        {
          throw new System.InvalidOperationException("There are currently no stylists available for new clients.");
        }
      }
      catch (Exception ex)
      {
        return View("Error", ex.Message);
      }
    }

    [HttpPost]
    public ActionResult Create(Client client)
    {
      try
      {
        if (String.IsNullOrWhiteSpace(client.Name) || String.IsNullOrWhiteSpace(client.Notes))
        {
          throw new System.InvalidOperationException("Invalid input");
        }
        else
        {
          _db.Clients.Add(client);
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
      Client thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
      ViewBag.Stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == thisClient.StylistId);
      return View(thisClient);
    }

    public ActionResult Delete(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
      return View(thisClient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
      _db.Clients.Remove(thisClient);
      _db.SaveChanges();
      return RedirectToAction("Index", "Stylists");
    }
  }
}