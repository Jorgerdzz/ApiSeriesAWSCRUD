using ApiSeriesAWSCRUD.Data;
using ApiSeriesAWSCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSeriesAWSCRUD.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        public async Task<Serie> FindSerieAsync(int id)
        {
            return await this.context.Series
                .FirstOrDefaultAsync(s => s.IdSerie == id);
        }

        private async Task<int> GetMaxIdSerieAsync()
        {
            return await this.context.Series.MaxAsync(x => x.IdSerie) + 1;
        }

        public async Task CreateSerieAsync(string nombre, string imagen, int anyo)
        {
            Serie s = new Serie
            {
                IdSerie = await this.GetMaxIdSerieAsync(),
                Nombre = nombre,
                Imagen = imagen,
                Anyo = anyo
            };
            await this.context.Series.AddAsync(s);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateSerieAsync(int id, string nombre, string imagen, int anyo)
        {
            Serie s = await this.FindSerieAsync(id);
            s.Nombre = nombre;
            s.Imagen = imagen;
            s.Anyo = anyo;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteSerieAsync(int id)
        {
            Serie s = await this.FindSerieAsync(id);
            this.context.Series.Remove(s);
            await this.context.SaveChangesAsync();
        }

    }
}
