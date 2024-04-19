using API_Bus.Models;

namespace API_Bus
{
    public class Seed
    {
        private readonly DatabaseContext databaseContext;

        public Seed(DatabaseContext context)
        {
            this.databaseContext = context;
        }

        public void SeedDataContext()
        {
            var Medicaments = new List<Medicament> {
            new Medicament()
            {
                Name = "ABEVMY 25 mg/mL",
                Description = "solution à diluer pour perfusion"
            },
            new Medicament()
            {
                Name = "ABIES NIGRA BOIRON",
                Description = "degré de dilution compris entre 2CH à 30CH et 4DH à 60DH"
            },
            new Medicament()
            {
                Name = "ABILIFY MAINTENA 300 mg",
                Description = "poudre et solvant pour suspension injectable à libération prolongée"
            },
            new Medicament()
            {
                Name = "ACAMPROSATE BIOGARAN 333 mg",
                Description = "comprimé pelliculé gastro-résistant"
            },
            new Medicament()
            {
                Name = "ACIDE ALENDRONIQUE ALTER 70 mg",
                Description = "comprimé pelliculé"
            },
            };

            databaseContext.Medicaments.AddRange(Medicaments);
            databaseContext.SaveChanges();

        }
    }
}
