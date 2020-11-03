using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea_Seis_y_Siete.Data
{
    public class AppDbServices
    {
        #region Public members and constructor
         private AppDbContext context;

         public AppDbServices(AppDbContext context)
         {
            this.context = context;
        }
        #endregion

        #region User refered methods
        public async Task<bool> checkIfUsuarioAlreadyExistsAsync(string correo)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var user = await context.Usuarios.FindAsync(correo);

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<Usuario> registerUsuarioAsync(Usuario usuario)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            await context.Usuarios.AddAsync(usuario);
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }

            return usuario;
        }
        public async Task<bool> checkCredentialsAsync (Usuario usuario)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var user = await context.Usuarios.Where(
                u => u.Correo == usuario.Correo && u.Clave == usuario.Clave)
                .FirstOrDefaultAsync();
            
            if (user != null)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
        public async Task<Usuario> GetUsuarioAsync(string correo)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var user = await context.Usuarios.FindAsync(correo);
            return user;
        }
        public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            context.Usuarios.Update(usuario);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return usuario;
        }

        #endregion

        #region Theasures refered Methods
        public async Task<List<Tesoro>> GetTesorosAsync(string correo)
        {
            var user = await GetUsuarioAsync(correo);
            var Theasures = await context.Tesoros.Where(t => t.Usuario == user).ToListAsync();
            return Theasures;
        }
        public async Task<Tesoro> CreateTesoroAsync(Tesoro tesoro)
        {
            await context.AddAsync(tesoro);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return tesoro;
        }
        public async Task<Tesoro> UpdateTesoroAsync(Tesoro tesoro)
        {
            context.Update(tesoro);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            } 
            return tesoro;
        } 
        public async Task<Tesoro> DeleteTesoroAsync(Tesoro tesoro)
        {
            context.Tesoros.Remove(tesoro);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return tesoro;
        }
        #endregion
    }
}
