﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdminView.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PickadosGenNHibernate.EN.Pickados.SportEN> SportENs { get; set; }

        public System.Data.Entity.DbSet<PickadosGenNHibernate.EN.Pickados.CompetitionEN> CompetitionENs { get; set; }

        public System.Data.Entity.DbSet<PickadosGenNHibernate.EN.Pickados.TeamEN> TeamEN { get; set; }

        public System.Data.Entity.DbSet<PickadosGenNHibernate.EN.Pickados.PlayerEN> PlayerENs { get; set; }

        public System.Data.Entity.DbSet<PickadosGenNHibernate.EN.Pickados.MatchEN> Event_EN { get; set; }

        public System.Data.Entity.DbSet<PickadosGenNHibernate.EN.Pickados.RequestEN> RequestENs { get; set; }

        public System.Data.Entity.DbSet<PickadosGenNHibernate.EN.Pickados.PostEN> PostENs { get; set; }

        public System.Data.Entity.DbSet<PickadosGenNHibernate.EN.Pickados.PickEN> PickENs { get; set; }
    }
}