using josmeyly_Duarte_Ap1.DAL;
using josmeyly_Duarte_Ap1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace josmeyly_Duarte_Ap1.Services
{
    
        public class ModeloService(IDbContextFactory<Contexto> DbFactory)
        {
            public async Task<bool> Guardar(Modelo modelo)
            {
                if (!await Existe(modelo.ModeloId))
                    return await Insertar(modelo);
                else
                    return await Modificar(modelo);
            }

            private async Task<bool> Existe(int modeloId)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.Modelo
                    .AnyAsync(m => m.ModeloId == modeloId);
            }

            private async Task<bool> Insertar(Modelo modelo)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                contexto.Modelo.Add(modelo);
                return await contexto.SaveChangesAsync() > 0;
            }

            private async Task<bool> Modificar(Modelo modelo)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                contexto.Update(modelo);
                return await contexto
                    .SaveChangesAsync() > 0;
            }

            public async Task<Modelo?> Buscar(int modeloId)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.Modelo
                    .FirstOrDefaultAsync(m => m.ModeloId == modeloId);
            }

            public async Task<bool> Eliminar(int modeloId)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.Modelo
                    .Where(m => m.ModeloId == modeloId)
                    .ExecuteDeleteAsync() > 0;

            }

            public async Task<List<Modelo>> Listar(Expression<Func<Modelo, bool>> criterio)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.Modelo.Include(t => t)
                    .Where(criterio)
                    .ToListAsync();
            }

            public async Task<bool> ExisteModelo(int modeloId)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Modelo
                .AnyAsync(m => m.ModeloId != modeloId);
                       

            }

        }
}
