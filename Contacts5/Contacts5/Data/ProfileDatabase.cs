using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Contacts5.Models;
using SQLite;

namespace Contacts5.Data
{
    public class ProfileDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ProfileDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Profile>().Wait();
        }

        public Task<List<Profile>> GetProfilesAsync()
        {
            return _database.Table<Profile>().ToListAsync();
        }

        public Task<Profile> GetProfileAsync(int id)
        {
            return _database.Table<Profile>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveProfileAsync(Profile profile)
        {
            if (profile.ID != 0)
            {
                return _database.UpdateAsync(profile);
            }
            else
            {
                return _database.InsertAsync(profile);
            }
        }

        public Task<int> DeleteProfileAsync(Profile profile)
        {
            return _database.DeleteAsync(profile);
        }
    }
}
