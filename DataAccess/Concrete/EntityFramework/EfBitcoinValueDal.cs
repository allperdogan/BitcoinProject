using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBitcoinValueDal : EfEntityRepositoryBase<BitcoinValue, BitcoinContext>, IBitcoinValueDal
    {
        public async Task AddAsync(BitcoinValue entity)
        {
            using (var context = new BitcoinContext())
            {
                context.Set<BitcoinValue>().Add(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
