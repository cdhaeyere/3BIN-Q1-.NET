// See https://aka.ms/new-console-template for more information
using LINQDataContext;

DataContext dc = new DataContext();

/*
 * Exercice 2.1
 */
// Ecrire une requête pour présenter, pour chaque étudiant, le nom de l’étudiant, la date de naissance, le login et le résultat pour l’année de l’étudiant.
var QueryResult = dc.Students
    .Select(s => new { Nom = s.Last_Name, DateNaissance = s.BirthDate, Login = s.Login, ResultatAnnee = s.Year_Result });

foreach (var Result in QueryResult)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 2.2
 */
// Ecrire une requête pour présenter, pour chaque étudiant, son nom complet (nom et prénom séparés par un espace), son id et sa date de naissance. L ’objectif pour cet exercice est de réaliser un maximum dans le query et non dans l’affichage.
var QueryResult2 = dc.Students
    .Select(s => new { Full_Name = s.Last_Name + " " + s.First_Name, Id = s.Student_ID, DateNaissance = s.BirthDate });

foreach (var Result in QueryResult2)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 2.3
 */
// Ecrire une requête pour présenter, pour chaque étudiant, dans une seule colonne l’ensemble des données relatives séparées par un « | ».
var QueryResult3 = dc.Students
    .Select(s => new { Full_Student = s.Last_Name + "|" + s.First_Name + "|" + s.Login });

foreach (var Result in QueryResult3)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 3.1
 */
// Pour chaque étudiant né avant 1955, donner le nom, le résultat annuel et le statut. Le statut prend la valeur « OK » si l’étudiant a obtenu au moins 12 comme résultat annuel et « KO » dans le cas contraire.
var QueryResult4 = dc.Students
    .Where(s => s.BirthDate.Year < 1955)
    .Select(s => new { Nom = s.Last_Name, Resultat_Annuel = s.Year_Result, Status = (s.Year_Result < 12) ? "KO" : "OK" });

foreach (var Result in QueryResult4)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 3.2
 */
// Donner pour chaque étudiant né entre 1955 et 1965 le nom, le résultat annuel et la catégorie à laquelle il appartient. La catégorie est en fonction du résultat obtenu :	< 10 : inférieure ;  > 10 : supérieure ; = 10 : neutre .
var QueryResult5 = dc.Students
    .Where(s => s.BirthDate.Year >= 1955 && s.BirthDate.Year <= 1965)
    .Select(s => new { Nom = s.Last_Name, Resultat_Annuel = s.Year_Result, Status = (s.Year_Result < 10) ? "inférieure" : (s.Year_Result > 10) ? "supérieure" : "neutre" });

foreach (var Result in QueryResult5)
{
    Console.WriteLine(Result);
}

/*
 * * Exercice 3.3
 */
// Ecrire une requête pour présenter le nom et l’id de section de tous les étudiants dont le nom de famille se termine par « r ».
var QueryResult6 = dc.Students
    .Where(s => s.Last_Name.EndsWith("r"))
    .Select(s => new { Nom = s.Last_Name, Id_Section = s.Section_ID });

foreach (var Result in QueryResult6)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 3.4
 */
// Ecrire une requête pour présenter le nom et le résultat annuel classé par résultats annuels décroissants de tous les étudiants qui ont obtenu un résultat inférieur ou égal à 3
var QueryResult7 = dc.Students
    .Where(s => s.Year_Result <= 3)
    .OrderByDescending(s => s.Year_Result)
    .Select(s => new { Nom = s.Last_Name, Resultat_Annuel = s.Year_Result });

foreach (var Result in QueryResult7)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 3.5
 */
// Ecrire une requête pour présenter le nom complet (nom et prénom séparés par un espace) et le résultat annuel classé par ordre croissant sur le nom des étudiants appartenant à la section 1110.
var QueryResult8 = dc.Students
    .Where(s => s.Section_ID == 1110)
    .OrderBy(s => s.Last_Name)
    .Select(s => new { Nom_Complet = s.Last_Name + " " + s.First_Name, Resultat_Annuel = s.Year_Result });

foreach (var Result in QueryResult8)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 3.6
 */
// Ecrire une requête pour présenter le nom, l’id de section et le résultat annuel classé par ordre croissant sur la section de tous les étudiants appartenant aux sections 1010 et 1020 ayant un résultat annuel qui n’est pas compris entre 12 et 18.
var QueryResult9 = dc.Students
    .Where(s => (s.Section_ID == 1010 || s.Section_ID == 1020) && (s.Year_Result < 12 || s.Year_Result > 18))
    .OrderBy(s => s.Section_ID)
    .Select(s => new { Nom = s.Last_Name, Id_Section = s.Section_ID, Resultat_Annuel = s.Year_Result });

foreach (var Result in QueryResult9)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 3.7
 */
// Ecrire une requête pour présenter le nom, l’id de section et le résultat annuel sur 100 ( nommer une colonne result_100) classé par ordre décroissant du résultat de tous les étudiants appartenant aux sections commençant par 13 et ayant un résultat annuel sur 100 inférieur ou égal à 60.
var QueryResult10 = dc.Students
    .Where(s => s.Section_ID.ToString().StartsWith("13") && s.Year_Result <= 60)
    .OrderByDescending(s => s.Year_Result)
    .Select(s => new { Nom = s.Last_Name, Id_Section = s.Section_ID, Resultat_Annuel = s.Year_Result, Resultat_100 = s.Year_Result * 100 / 20 });

foreach (var Result in QueryResult10)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 4.1
 */
// Donner le résultat annuel moyen pour l’ensemble des étudiants.
var QueryResult11 = dc.Students
    .Average(s => s.Year_Result);

Console.WriteLine(QueryResult11);

/*
 * Exercice 4.2
 */
// Donner le plus haut résultat annuel obtenu par un étudiant.
var QueryResult12 = dc.Students
    .Max(s => s.Year_Result);

Console.WriteLine(QueryResult12);

/*
 * Exercice 4.3
 */
// Donner la somme des résultats annuels.
var QueryResult13 = dc.Students
    .Sum(s => s.Year_Result);

Console.WriteLine(QueryResult13);

/*
 * Exercice 4.4
 */
// Donner le résultat annuel le plus faible.
var QueryResult14 = dc.Students
    .Min(s => s.Year_Result);

Console.WriteLine(QueryResult14);

/*
 * Exercice 4.5
 */
// Donner le nombre de lignes qui composent la « table » STUDENT.
var QueryResult15 = dc.Students
    .Count();

Console.WriteLine(QueryResult15);

/*
 * Exercice 5.1
 */
// Donner pour chaque section, le résultat maximum (Max_Result) obtenu par les étudiants.
var QueryResult16 = dc.Students
    .GroupBy(s => s.Section_ID)
    .Select(s => new { Id_Section = s.Key, Max_Result = s.Max(s => s.Year_Result) });

foreach (var Result in QueryResult16)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 5.2
 */
// Donner pour toutes les sections commençant par 10, le résultat annuel moyen (AVG_Result) obtenu par les étudiants.
var QueryResult17 = dc.Students
    .Where(s => s.Section_ID.ToString().StartsWith("10"))
    .GroupBy(s => s.Section_ID)
    .Select(s => new { Id_Section = s.Key, Avg_Result = s.Average(s => s.Year_Result) });

foreach (var Result in QueryResult17)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 5.3
 */
// Donner le résultat moyen (AVG_Result) et le mois en chiffre (BirtMonth) pour les étudiants né le même mois entre 1970 et 1985.
var QueryResult18 = dc.Students
    .Where(s => s.BirthDate.Year >= 1970 && s.BirthDate.Year <= 1985)
    .GroupBy(s => s.BirthDate.Month)
    .Select(s => new { BirthMonth = s.Key, Avg_Result = s.Average(s => s.Year_Result) });

foreach (var Result in QueryResult18)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 5.4
 */
// Donner le résultat moyen (AVG_Result) et le mois en chiffre (BirtMonth) pour les étudiants né le même mois entre 1970 et 1985.
var QueryResult19 = dc.Students
    .Where(s => s.BirthDate.Year >= 1970 && s.BirthDate.Year <= 1985)
    .GroupBy(s => s.BirthDate.Month)
    .Select(s => new { BirthMonth = s.Key, Avg_Result = s.Average(s => s.Year_Result) });

foreach (var Result in QueryResult19)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 5.5
 */
// Donner pour chaque cours le nom du professeur responsable ainsi que la section dont il fait partie.
var query = dc.Courses
    .Join(dc.Professors,
        cours => cours.Professor_ID,
        prof => prof.Professor_ID,
        (cours, prof) => new { cours, prof })
    .Join(dc.Sections,
        entry => entry.prof.Section_ID,
        sect => sect.Section_ID,
        (entry, sect) => new { entry.cours.Course_Name, entry.prof.Professor_Name, sect.Section_Name })
    .Select(result => new { result.Course_Name, result.Professor_Name, result.Section_Name });

foreach (var Result in QueryResult20)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 5.6
 */
// Donner pour chaque section, l’id, le nom et le nom de son délégué. Classer les sections dans l’ordre inverse des ids de section.
var QueryResult21 = dc.Sections
    .Join(dc.Students, s => s.Delegate_ID, st => st.Student_ID, (s, st) => new { s, st })
    .Select(s => new { Id_Section = s.s.Section_ID, Nom_Section = s.s.Section_Name, Nom_Delegue = s.st.Last_Name })
    .OrderByDescending(s => s.Id_Section);

foreach (var Result in QueryResult21)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 5.7
 */
// Donner pour toutes les sections les professeurs qui en sont membres.
var QueryResult22 = dc.Sections
    .Join(dc.Professors, s => s.Section_ID, p => p.Section_ID, (s, p) => new { s, p })
    .Select(s => new { Id_Section = s.s.Section_ID, Nom_Section = s.s.Section_Name, Nom_Professeur = s.p.Professor_Name });

foreach (var Result in QueryResult22)
{
    Console.WriteLine(Result);
}

/*
 * Exercice 5.11
 */
// Donner pour chaque professeur son id et le total des crédits ECTS (ECTSTOT) qui lui sont attribués. La liste est triée par ordre décroissant de la somme des crédits alloués.
var QueryResult23 = dc.Professors
    .Join(dc.Courses, p => p.Professor_ID, c => c.Professor_ID, (p, c) => new { p, c })
    .GroupBy(s => s.p.Professor_ID)
    .Select(s => new { Id_Professeur = s.Key, ECTSTOT = s.Sum(s => s.c.Course_Ects) })
    .OrderByDescending(s => s.ECTSTOT);

foreach (var Result in QueryResult23)
{
    Console.WriteLine(Result);
}