using Generador_Token.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Generador_Token.Data
{
    internal class DataBase
    {
        readonly SQLiteAsyncConnection Connection;

        public DataBase(string dbPath, SQLiteAsyncConnection liteConnection)
        {
            liteConnection = new SQLiteAsyncConnection(dbPath);
            liteConnection.CreateTableAsync<EmpresaModel>().Wait();
            Connection = liteConnection;
        }

        public async Task<int> insertEmpresaAsync(EmpresaModel empresa)
        {
            return await Connection.InsertAsync(empresa);
        }
        public async Task<List<EmpresaModel>> getEmpresaAsync()
        {
            return await Connection.Table<EmpresaModel>().ToListAsync().ConfigureAwait(false);
        }
        public async Task<int> updateEmpresaAsync(EmpresaModel empresa)
        {
            return await Connection.UpdateAsync(empresa);
        }
    }
}
