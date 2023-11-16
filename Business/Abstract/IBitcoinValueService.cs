using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBitcoinValueService
    {
        IDataResult<List<BitcoinValue>> GetAll();
        IResult Add(BitcoinValue bitcoinValue);
        Task<IResult> AddBitcoinValueAsync(decimal value);
    }
}
