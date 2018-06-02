using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2Ninject.Models
{
    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }
}
