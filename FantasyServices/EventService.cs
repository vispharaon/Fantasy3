using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Security;
using Newtonsoft.Json;
using System.Web;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Data.Entity.Validation;
namespace FantasyServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EventService" in both code and config file together.
    public class EventService : IEventService
    {


        public bool CreateEvent(string obj)
        {
            string provjera = "";

            try
            {
                fantasyEntities db = new fantasyEntities();

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(events));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(obj));
                events e = db.events.Add((events)ser.ReadObject(ms));
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    provjera = eve.Entry.Entity.GetType().Name + " " + eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        provjera = ve.PropertyName + " " + ve.ErrorMessage;
                    }
                }

            }

            if (provjera.Equals("")) return true;
            else return false;


        }




        public bool UpdateEvent(string obj, string ID)
        {
            string provjera = "";

            try
            {
                fantasyEntities db = new fantasyEntities();

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(events));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(obj));
                events e = db.events.Where(k => k.idEvents.ToString() == ID).FirstOrDefault();
                if (e == null) provjera = "nema";
                e = (events)ser.ReadObject(ms);

                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    provjera = eve.Entry.Entity.GetType().Name + " " + eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        provjera = ve.PropertyName + " " + ve.ErrorMessage;
                    }
                }

            }

            if (provjera.Equals("")) return true;
            else return false;
        }

        public bool DeleteEvent(string ID)
        {
            string provjera = "";
            try
            {
                fantasyEntities db = new fantasyEntities();



                events e = db.events.Where(k => k.idEvents.ToString() == ID).FirstOrDefault();
                if (e == null) provjera = "nema";
                else
                {
                    db.events.Attach(e);
                    db.events.Remove(e);

                    db.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    provjera = eve.Entry.Entity.GetType().Name + " " + eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        provjera = ve.PropertyName + " " + ve.ErrorMessage;
                    }
                }

            }

            if (provjera.Equals("")) return true;
            else return false;

        }

        public string ReadEvent(string ID)
        {
            string provjera = "";
            string jsonString = "";
            try
            {

                fantasyEntities db = new fantasyEntities();
                var context = db.events.Where(a => a.idEvents.ToString() == ID).FirstOrDefault();
                if (context == null) provjera = "nema";
                else
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(user));
                    MemoryStream ms = new MemoryStream();
                    ser.WriteObject(ms, context);
                    jsonString = Encoding.UTF8.GetString(ms.ToArray());
                    ms.Close();
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    provjera = eve.Entry.Entity.GetType().Name + " " + eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        provjera = ve.PropertyName + " " + ve.ErrorMessage;
                    }
                }

            }

            return jsonString;
        }

        public List<string> ReadAllEvents()
        {
            string provjera = "";
            List<string> jsonString = new List<string>();
            try
            {

                fantasyEntities db = new fantasyEntities();
                var context = db.events.ToList();
                if (context == null) provjera = "nema";
                else
                {
                    foreach (events e in context)
                    {
                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(events));
                        MemoryStream ms = new MemoryStream();
                        ser.WriteObject(ms, e);
                        jsonString.Add(Encoding.UTF8.GetString(ms.ToArray()));
                        ms.Close();
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    provjera = eve.Entry.Entity.GetType().Name + " " + eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        provjera = ve.PropertyName + " " + ve.ErrorMessage;
                    }
                }

            }



            return jsonString;
        }
    }
}
