using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SistemaControlEstudiantesUNI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaControlEstudiantesUNI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {

        ApplicationDbContext contexto = new ApplicationDbContext();
       
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contexto));
            string UserName = form["txtEmail"];
            string email= form["txtEmail"];
            string pass = form["txtPassword"];

            var user = new ApplicationUser();
            user.UserName = UserName;
            user.Email = email;
            string pwd = pass;


            var newUser = usermanager.Create(user, pwd);
            if (newUser.Succeeded)
            {
                Success("Usuario: "+ UserName +"creado con exito!!");
            }
            //Hacer Cambio posterior a Home de bienvenida de usuario loggeado
            return View();
        }
        public ActionResult CreateRole()
        {


            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(FormCollection form)
        {
            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(contexto));

            string RoleName = form["RoleName"];
            if (!rolemanager.RoleExists(RoleName))
            {
                //Create Admin
                var role = new IdentityRole(RoleName);

                var newRole= rolemanager.Create(role);
                if (newRole.Succeeded)
                {
                    Success("Rol creado con exito!!");
                }
                

            }
            else
            {


                Danger("Error al crear Role, ya existe");
            }
               
            return View();
        }
        public ActionResult AssignRole()
        {
            var lstUsuarios = contexto.Users.Select(x => x);
            ViewBag.lstUsiario = lstUsuarios;

            var lstRoles= contexto.Roles.Select(x => x);
            ViewBag.lstRoles = lstRoles;
            return View();
        }


        [HttpPost]
        public ActionResult AssignRole(FormCollection form)
        {
            string user = form["Usuarios"];
            string role = form["Roles"];

            ApplicationUser usuario = contexto.Users.Where(u=>u.Id.Equals(user,StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            // roleSeleccionado = contexto.Roles.Where(u => u.Id.Equals(role, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contexto));
            var ban=usermanager.AddToRole(usuario.Id,role);

            if (ban.Succeeded)
            {
                Success("Rol asignado a usuario exitosamente");
            }
            else
            {
                Danger("Error en la asignación de roles");
            }
            
            return View();
        }
    }
}