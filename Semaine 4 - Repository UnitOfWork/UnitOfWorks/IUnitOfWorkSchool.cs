using School.Repository;
using SchoolApp.Models;

namespace School.UnitOfWork
{
    interface IUnitOfWorkSchool
    {
        IRepository<Section> SectionsRepository { get; }

        IStudentRepository StudentsRepository { get; }
    }
}
