using OrgOffering.Data;
using OrgOffering.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrgOffering.Repository
{
    public class tblProductRepository
    {
        protected readonly GTMContext _context = new GTMContext();

        // GET ALL: Products
        public IEnumerable<TblProduct> GetAll()
        {
            return _context.TblProduct.ToList();
        }

        // TO DO: Add ‘Get By Id’
        // TO DO: Add ‘Create’
        // TO DO: Add ‘Edit’
        // TO DO: Add ‘Delete’
        // TO DO: Add ‘Exists’

    }
}
