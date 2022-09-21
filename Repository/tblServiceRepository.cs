using OrgOffering.Data;
using OrgOffering.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrgOffering.Repository
{
    public class tblServiceRepository
    {
        protected readonly GTMContext _context = new GTMContext();

        // GET ALL: Products
        public IEnumerable<TblService> GetAll()
        {
            return _context.TblService.ToList();
        }

        // TO DO: Add ‘Get By Id’
        // TO DO: Add ‘Create’
        // TO DO: Add ‘Edit’
        // TO DO: Add ‘Delete’
        // TO DO: Add ‘Exists’
    }
}
