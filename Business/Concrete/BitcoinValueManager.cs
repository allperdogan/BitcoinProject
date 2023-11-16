using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BitcoinValueManager : IBitcoinValueService
    {
        IBitcoinValueDal _bitcoinValueDal;

        public BitcoinValueManager(IBitcoinValueDal bitcoinValueDal)
        {
            _bitcoinValueDal = bitcoinValueDal;
        }
        
        public IResult Add(BitcoinValue bitcoinValue)
        {
            _bitcoinValueDal.Add(bitcoinValue);
            return new SuccessResult();
        }

        public IDataResult<List<BitcoinValue>> GetAll()
        {
            
            return new SuccessDataResult<List<BitcoinValue>>(_bitcoinValueDal.GetAll());
        }

        public async Task<IResult> AddBitcoinValueAsync(decimal value)
        {
            var bitcoinValue = new BitcoinValue
            {
                timestamp = DateTime.UtcNow,
                value = value
            };

            await _bitcoinValueDal.AddAsync(bitcoinValue);

            return new SuccessResult("Bitcoin value added successfully.");
        }
    }
}
