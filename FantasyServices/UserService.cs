using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Data.Entity.Validation;

namespace FantasyServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminService" in both code and config file together.
    public class UserService : IUserService
    {
        


        public bool IsValid(string user, string password)
        {
            fantasyEntities db = new fantasyEntities();

            using (db)
            {
                if (db.user.Where(a => a.email.Equals(user) && a.password.Equals(password)).FirstOrDefault() != null)
                {
                    return true;
                }
                else return false;
            }



        }


        public bool CreateUser(string obj)
        {
            string provjera="";
            
            try
            {
                fantasyEntities db = new fantasyEntities();

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(user));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(obj));
                user a = db.user.Add((user)ser.ReadObject(ms));
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    provjera = eve.Entry.Entity.GetType().Name + " " + eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        provjera= ve.PropertyName+" "+ve.ErrorMessage;
                    }
                }
               
            }

            if(provjera.Equals("")) return true;
            else return false;

          
        }




        public bool UpdateUser(string obj, string user)
        {
            string provjera = "";

            try
            {
                fantasyEntities db = new fantasyEntities();

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(user));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(obj));
                user a = db.user.Where(k => k.email == user).FirstOrDefault();
                if (a == null) provjera = "nema";
                a = (user)ser.ReadObject(ms);
                
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

        public bool DeleteUser(string user)
        {
            string provjera = "";
            try
            {
                fantasyEntities db = new fantasyEntities();

               
                
                user a = db.user.Where(k => k.email == user).FirstOrDefault();
                if (a == null) provjera = "nema";
                else
                {
                    db.user.Attach(a);
                    db.user.Remove(a);

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

        public string ReadUser(string email)
        {
            string provjera = "";
            string jsonString="";
            try
            {

                fantasyEntities db = new fantasyEntities();
                var context = db.user.Where(a => a.email == email).FirstOrDefault();
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

        public List<string> ReadAllUsers()
        {
            string provjera = "";
            List<string> jsonString = new List<string>();
            try
            {

                fantasyEntities db = new fantasyEntities();
                var context = db.user.ToList();
                if (context == null) provjera = "nema";
                else
                {
                    foreach (user a in context)
                    {
                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(user));
                        MemoryStream ms = new MemoryStream();
                        ser.WriteObject(ms, a);
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
        public bool InsertImage(string path, string mail)
        {
            string provjera = "";
            try
            {
                fantasyEntities db = new fantasyEntities();
                var context = db.user.Where(a => a.email == mail).FirstOrDefault();
                if (context == null)
                    provjera = "nema";
                else
                {
                    context.image = path;
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
    }
}
    

