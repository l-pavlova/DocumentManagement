using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    public class DataMapper<TEntity> where TEntity : class, new()
    {
        public TEntity Map(DataRow row)
        {
            var colNames = row.Table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();

            var properties = (typeof(TEntity)).GetProperties().
                Where(x => x.GetCustomAttributes(typeof(DataNamesAttribute), true)
               .Any()).ToList();


            TEntity entity = new TEntity();
            foreach (var item in properties)
            {
                PropertyMapHelper.Map(typeof(TEntity), row, item, entity);
            }
            return entity;
        }
        public IEnumerable<TEntity> Map(DataTable table)
        {
            var colNames = table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();

            var properties = (typeof(TEntity)).GetProperties().
                Where(x => x.GetCustomAttributes(typeof(DataNamesAttribute), true).
                Any()).ToList();
            List<TEntity> entities = new List<TEntity>();
            foreach (DataRow row in table.Rows)
            {
                TEntity entity = new TEntity();
                foreach (var prop in properties)
                {
                    PropertyMapHelper.Map(typeof(TEntity), row, prop, entity);
                }
                entities.Add(entity);
            }
            return entities;
        }
    }
}
