// See https://aka.ms/new-console-template for more information


using School.Repository;
using School.UnitOfWork;
using SchoolApp.Models;

SchoolContext context = new SchoolContext();

/* version avec uniquement Repository */

//BaseRepository<Section> repoSect = new BaseRepositorySQL<Section>(context);
//StudentRepositorySQLServer repoStud = new StudentRepositorySQLServer(context);



IUnitOfWorkSchool unitOfWorkSchool = new UnitOfWorkSchoolDB(context);
//IUnitOfWorkSchool unitOfWorkSchool = new UnitOfWorkSchoolMem();
IRepository<Section> repoSect = unitOfWorkSchool.SectionsRepository;
IStudentRepository repoStud = unitOfWorkSchool.StudentsRepository;

Section sectInfo = new Section { Name = "Info" };
repoSect.Save(sectInfo, s => s.Name.Equals(sectInfo.Name));
Section sectDiet = new Section { Name = "Diet" };
repoSect.Save(sectDiet, s => s.Name.Equals(sectDiet.Name));

IList<Section> sections = repoSect.GetAll().ToList();

foreach (Section s in sections)
{
    Console.WriteLine(s.Name);
}
Console.WriteLine("-----------------------------------------");

Student studinfo = new Student
{
    Firstname = "Jean",
    Name = "Bernard",
    Section = sectInfo,
    YearResult = 100
};

Student studdiet = new Student
{
    Firstname = "Luca",
    Name = "Henri",
    Section = sectDiet,
    YearResult = 120
};


Student studinfo2 = new Student
{
    Firstname = "Albert",
    Name = "Jacquard",
    Section = sectInfo,
    YearResult = 110
};

repoStud.Save(studinfo, s => s.Name.Equals(studinfo.Name) && s.Firstname.Equals(studinfo.Firstname));
repoStud.Save(studinfo2, s => s.Name.Equals(studinfo2.Name) && s.Firstname.Equals(studinfo2.Firstname));
repoStud.Save(studdiet, s => s.Name.Equals(studdiet.Name) && s.Firstname.Equals(studdiet.Firstname));

IList<Student> studs = repoStud.GetStudentBySectionOrderByYearResult();

foreach (Student s in studs)
{
    Console.WriteLine("Section : " + s.Section.Name + " Etudiant : " + s.Name + " Resultat : " + s.YearResult);
}


Console.ReadLine();