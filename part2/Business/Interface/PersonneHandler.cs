using part2.Models;
using Infrastructure.Models;

public class PersonneHandler : IPersonneHandler
{
    private PersonneContext _context;

    public PersonneHandler(PersonneContext context)
    {
        _context = context;
    }
    public async Task<bool> AddPersonne(Personne personne)
    {
        try
        {
            if (HasValidAge(personne.DateDeNaissance))
            {
                _context.PersonneItems.Add(personne);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
        catch (Exception ex)
        {
            //log something
            return false;
        }
    }

    public IEnumerable<GetPersonnesDto> GetPersonnes()
    {
        var data = _context.PersonneItems.OrderBy(a => a.Nom);
        var ListPersonne = new List<GetPersonnesDto>();
        foreach (Personne dataPersonne in data)
        {
            ListPersonne.Add(new GetPersonnesDto(dataPersonne.Nom, dataPersonne.Prenom, (DateTime.Now.Year - dataPersonne.DateDeNaissance.Year).ToString()));
        }
        return ListPersonne;


    }

    private bool HasValidAge(DateTime age)
    {
        return DateTime.Now.Year - age.Year < 150;
    }
}
