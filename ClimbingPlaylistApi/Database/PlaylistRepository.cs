using ClimbingPlaylistApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClimbingPlaylistApi.Database
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private ClimbingDbContext _dbContext;

        public PlaylistRepository(DbContextOptions options)
        {
            _dbContext = new ClimbingDbContext(options);
        }

        public void Add(PlaylistModel playlist)
        {
            _dbContext.Add(playlist);
            _dbContext.SaveChanges();
        }

        public PlaylistModel Get(int id)
        {
            try
            {
                return (PlaylistModel)_dbContext.Find(typeof(PlaylistModel), id);
            }
            catch
            {
                throw new ArgumentException($"Playlist with Id {id} not found.");
            }
        }

        public void Remove(PlaylistModel playlist)
        {
            _dbContext.Remove(playlist);
            _dbContext.SaveChanges();
        }

        public void Update(PlaylistModel playlist)
        {
            _dbContext.Update(playlist);
            _dbContext.SaveChanges();
        }
    }
}
