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

    }
}
