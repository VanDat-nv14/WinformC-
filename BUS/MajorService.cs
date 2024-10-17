using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class MajorService
    {
        public List<Major> GetAllByFacylty(int facultyID)
        {
            StudentcontextDB context = new StudentcontextDB(); 
            return context.Majors.Where(p => p.FacultyID == facultyID).ToList();
        }
    }
}
