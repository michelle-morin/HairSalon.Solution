using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace HairSalon.Controllers
{
  public class AppointmentsController : Controller
  {
    private readonly HairSalonContext _db;

    public AppointmentsController(HairSalonContext db)
    {
      _db = db;
    } 

    public ActionResult Create()
    {
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Appointment appointment)
    {
      try
      {
        if (String.IsNullOrWhiteSpace(appointment.Date) || String.IsNullOrWhiteSpace(appointment.Notes))
        {
          throw new System.InvalidOperationException("Invalid input");
        }
        else if (Validation.CheckDateFormat(appointment.Date) == 1)
        {
          List<Appointment> existingAppts = _db.Appointments.Where(appt => appt.StylistId == appointment.StylistId).ToList();
          for (int i=0; i< existingAppts.Count; i++)
          {
            if (existingAppts[i].Date == appointment.Date || existingAppts[i].Time == appointment.Time)
            {
              throw new System.InvalidOperationException("Selected date and/or time unavailable. Please try again.");
            }
          }
          _db.Appointments.Add(appointment);
          _db.SaveChanges();
          return RedirectToAction("Index", "Stylists");
        }
        else
        {
          throw new System.InvalidOperationException("Invalid date format. Please try again.");
        }
      }
      catch (Exception ex)
      {
        return View("Error", ex.Message);
      }
    }
  }
}