using System.Collections.ObjectModel;
using System.Linq;

namespace DEKL.CP.Infra.Data.Migrations
{
    using Domain.Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EF.Context.DEKLCPDataContextEF>
    {
        public Configuration() => AutomaticMigrationsEnabled = false;

        protected override void Seed(EF.Context.DEKLCPDataContextEF context)
        {
            if (!context.States.Any())
            {
                var states = new Collection<State>
                {
                    new State {Name = "Acre", Initials = "AC"},
                    new State {Name = "Alagoas", Initials = "AL"},
                    new State {Name = "Amap�", Initials = "AP"},
                    new State {Name = "Amazonas", Initials = "AM"},
                    new State {Name = "Bahia", Initials = "BA"},
                    new State {Name = "Cear�", Initials = "CE"},
                    new State {Name = "Distrito Federal", Initials = "DF"},
                    new State {Name = "Esp�rito Santo", Initials = "ES"},
                    new State {Name = "Goi�s", Initials = "GO"},
                    new State {Name = "Maranh�o", Initials = "MA"},
                    new State {Name = "Mato Grosso", Initials = "MT"},
                    new State {Name = "Mato Grosso do Sul", Initials = "MS"},
                    new State {Name = "Minas Gerais", Initials = "MG"},
                    new State {Name = "Par�", Initials = "PA"},
                    new State {Name = "Para�ba", Initials = "PB"},
                    new State {Name = "Paran�", Initials = "PR"},
                    new State {Name = "Pernambuco", Initials = "PE"},
                    new State {Name = "Piau�", Initials = "PI"},
                    new State {Name = "Rio de Janeiro", Initials = "RJ"},
                    new State {Name = "Rio Grande do Norte", Initials = "RN"},
                    new State {Name = "Rio Grande do Sul", Initials = "RS"},
                    new State {Name = "Rond�nia", Initials = "RO"},
                    new State {Name = "Roraima", Initials = "RR"},
                    new State {Name = "Santa Catarina", Initials = "SC"},
                    new State {Name = "S�o Paulo", Initials = "SP"},
                    new State {Name = "Sergipe", Initials = "SE"},
                    new State {Name = "Tocantins", Initials = "TO"}
                };
                context.States.AddRange(states);
            }

            if (!context.Banks.Any())
            {
                var banks = new Collection<Bank>
                {
                    new Bank {Name = "Ita� Unibanco Holding S.A.", Number = 341},
                    new Bank {Name = "Bradesco S.A.", Number = 237},
                    new Bank {Name = "Banco do Brasil S.A.", Number = 1},
                    new Bank {Name = "Banco Santander (Brasil) S.A.", Number = 033},
                    new Bank {Name = "Banco Safra S.A.", Number = 422},
                    new Bank {Name = "Caixa Econ�mica Federal", Number = 104}
                };

                context.Banks.AddRange(banks);
            }
        }
    }
}