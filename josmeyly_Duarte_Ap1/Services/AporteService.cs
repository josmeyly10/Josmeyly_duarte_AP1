using josmeyly_Duarte_Ap1.DAL;
using josmeyly_Duarte_Ap1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace josmeyly_Duarte_Ap1.Services
{
    public class AporteService(IDbContextFactory<Contexto>DbFactory) 
    { 
     
        public async Task<bool> Guardar(Aporte aporte)
        {
            if (!await Existe(aporte.AporteId))
                return await Insertar(aporte);
            else
                return await Modificar(aporte);
        }
        
        public async Task<bool> Existe(int aporteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aporte
                .AnyAsync(a => a.AporteId == aporteId);
        }

        private async Task<bool> Insertar(Aporte aporte)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Aporte.Add(aporte);
            return await contexto.SaveChangesAsync() > 0;
        }
        
        private async Task<bool> Modificar(Aporte aporte)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(aporte);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Aporte?> Buscar(int aporteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aporte
                .FirstOrDefaultAsync(a => a.AporteId == aporteId);


        }
        public async Task<bool> Eliminar(int aporteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aporte
            .Where(a => a.AporteId == aporteId)
            .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Aporte>> Listar(Expression<Func<Aporte, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aporte
                .Where(criterio)
                .ToListAsync();
        }
        public async Task<bool> ExisteAporte(int AporteId, string persona)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aporte
                .AnyAsync(a => a.AporteId != AporteId &&
                a.Persona.ToLower().Equals(persona.ToLower()));
        }
    }



}









    