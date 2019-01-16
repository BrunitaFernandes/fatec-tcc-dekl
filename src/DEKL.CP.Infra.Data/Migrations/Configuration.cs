using System.Collections.ObjectModel;
using System.Linq;

namespace DEKL.CP.Infra.Data.Migrations
{
    using Domain.Entities;
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;

    internal sealed class Configuration : DbMigrationsConfiguration<EF.Context.DEKLCPDataContextEF>
    {
        public Configuration() => AutomaticMigrationsEnabled = true;

        protected override void Seed(EF.Context.DEKLCPDataContextEF context)
        {
            if (!context.Modules.Any())
            {
                var modules = new Collection<Module>
                    {
                        new Module
                        {
                            Name = "Contas a Pagar",
                            Description = "M�dulo de Contas a Pagar"
                        },
                        new Module
                        {
                            Name = "Fornecedor",
                            Description = "M�dulo de gerenciamento de Fornecedores"
                        },
                        new Module
                        {
                            Name = "Conta Banc�ria Interna",
                            Description = "M�dulo de gerenciamento de contas banc�rias internas"
                        },
                        new Module
                        {
                            Name = "Conta Banc�ria de Fornecedor",
                            Description = "M�dulo de gerenciamento de contas banc�rias de fornecedor"
                        },

                    };

                context.Modules.AddRange(modules);
            }

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

            if (!context.ProviderPhysicalPersons.Any())
            {
                var providersPhysicalPerson = new Collection<ProviderPhysicalPerson>
                    {
                        new ProviderPhysicalPerson
                        {
                            Name = "Igor Raimundo Ferreira",
                            CPF = "27079285852",
                            PhoneNumber = "15985369558",
                            Email = "iigorraimundoferreira@nine9.com.br",
                            ApplicationUserId = 1,
                            ModuleId = 2,
                            Address = new Address
                            {
                                Street = "Rua Paulo Muller",
                                Number = "757",
                                ZipCode = "18087763",
                                Neighborhood = "Jardim Residencial Morada das Flores",
                                City = "Sorocaba",
                                StateId = 25
                            },
                        },
                        new ProviderPhysicalPerson
                        {
                            Name = "Andrea Aparecida Rocha",
                            CPF = "05733098848",
                            PhoneNumber = "15996947613",
                            ApplicationUserId = 1,
                            ModuleId = 2,
                            Email = "andreaaparecidarocha-74@stilomovelaria.com.br",
                            Address = new Address
                            {
                                Street = "Rua Interventor Jo�o Alberto",
                                Number = "418",
                                ZipCode = "18271030",
                                Neighborhood = "Jardim S�o Paulo",
                                City = "Tatu�",
                                StateId = 25
                            }
                        },
                        new ProviderPhysicalPerson
                        {
                            Name = "Nicolas Vinicius Tom�s Castro",
                            CPF = "35545958886",
                            PhoneNumber = "15994888577",
                            ApplicationUserId = 1,
                            ModuleId = 2,
                            Email = "nnicolasviniciustomascastro@hotmail.com",
                            Address = new Address
                            {
                                Street = "Avenida General Waldomiro de Lima",
                                Number = "443",
                                ZipCode = "18170970",
                                Neighborhood = "Centro",
                                City = "Piedade",
                                StateId = 25
                            }
                        },
                        new ProviderPhysicalPerson
                        {
                            Name = "Camila Simone Barros",
                            CPF = "78123513860",
                            PhoneNumber = "15985504488",
                            Email = "ccamilasimonebarros@hotmail.com",
                            ApplicationUserId = 1,
                            ModuleId = 2,
                            Address = new Address
                            {
                                Street = "Rua Astrogilda Ayrola Ribeiro",
                                Number = "443",
                                ZipCode = "18086703",
                                Neighborhood = "Jardim das Azal�ias",
                                City = "Sorocaba",
                                StateId = 25
                            }
                        }
                    };

                context.ProviderPhysicalPersons.AddRange(providersPhysicalPerson);
            }

            if (!context.ProviderLegalPersons.Any())
            {
                var providersLegalPerson = new Collection<ProviderLegalPerson>
                    {
                        new ProviderLegalPerson
                        {
                            CorporateName = "Bianca e L�via Cont�bil Ltda",
                            CNPJ = "61844994000117",
                            StateRegistration = "356403594664",
                            PhoneNumber = "11991954444",
                            Email = "faleconosco@biancaeliviacontabilltda.com.br",
                            ApplicationUserId = 1,
                            ModuleId = 2,
                            Address = new Address
                            {
                                Street = "Rua S�o Jo�o",
                                Number = "853",
                                ZipCode = "18087763",
                                Neighborhood = "Vila Sorocabana",
                                City = "Guarulhos",
                                StateId = 25
                            }
                        },
                        new ProviderLegalPerson
                        {
                            CorporateName = "Nelson e Filipe A�os ME",
                            CNPJ = "15795557000133",
                            StateRegistration = "908863725724",
                            PhoneNumber = "1937565945",
                            Email = "representantes@nelsonefilipeacosme.com.br",
                            ApplicationUserId = 1,
                            ModuleId = 2,
                            Address = new Address
                            {
                                Street = "Travessa Jos� Pereira Cardoso",
                                Number = "120",
                                ZipCode = "13417757",
                                Neighborhood = "Nova Am�rica",
                                City = "Piracicaba",
                                StateId = 25
                            }
                        },
                        new ProviderLegalPerson
                        {
                            CorporateName = "Sabrina e Jos� Constru��es Ltda",
                            CNPJ = "82522372000142",
                            StateRegistration = "519482566719",
                            PhoneNumber = "1135337707",
                            ApplicationUserId = 1,
                            ModuleId = 2,
                            Email = "desenvolvimento@sabrinaejoseconstrucoesltda.com.br",
                            Address = new Address
                            {
                                Street = "Rua Morioka",
                                Number = "951",
                                ZipCode = "06365-595",
                                Neighborhood = "Jardim Ang�lica",
                                City = "Carapicu�ba",
                                StateId = 25
                            }
                        },
                        new ProviderLegalPerson
                        {
                            CorporateName = "Lorena e Ayla Consultoria Financeira Ltda",
                            CNPJ = "97077956000123",
                            StateRegistration = "454805570260",
                            PhoneNumber = "15983130826",
                            ApplicationUserId = 1,
                            ModuleId = 2,
                            Email = "representantes@lorenaeaylaconsultoriafinanceiraltda.com.br",
                            Address = new Address
                            {
                                Street = "Rua Salgado Filho",
                                Number = "746",
                                ZipCode = "18280445",
                                Neighborhood = "Jardim Aeroporto",
                                City = "Tatu�",
                                StateId = 25
                            }
                        }
                    };

                context.ProviderLegalPersons.AddRange(providersLegalPerson);
            }

            if (!context.Banks.Any())
            {
                var banks = new Collection<Bank>
                    {
                        new Bank { Name = "Ita� Unibanco Holding S.A.", Number = 341 },
                        new Bank { Name = "Bradesco S.A.", Number = 237},
                        new Bank { Name = "Banco do Brasil S.A.", Number = 1},
                        new Bank { Name = "Banco Santander (Brasil) S.A.", Number = 033 },
                        new Bank { Name = "Banco Safra S.A.", Number = 422},
                        new Bank { Name = "Caixa Econ�mica Federal", Number = 104 }
                    };

                context.Banks.AddRange(banks);
            }

            if (!context.BankAgencies.Any())
            {
                var banksAgencies = new Collection<BankAgency>
                    {
                        new BankAgency
                        {
                            Number = 6582,
                            ManagerName = "F�bio de Lima",
                            BankId = 1,
                            Address = new Address
                            {
                                Street = "Avenida Pereira Da Silva",
                                Number = "1276",
                                ZipCode = "18095340",
                                Neighborhood = "Jardim Santa Ros�lia",
                                City = "Sorocaba",
                                StateId = 25
                            }
                        },
                        new BankAgency
                        {
                            Number = 1512,
                            PhoneNumber = "1532241044",
                            Email = "age1512@bb.com.br",
                            BankId = 3,
                            Address = new Address
                            {
                                Street = "Avenida Itavuvu",
                                Number = "516",
                                ZipCode = "18103000",
                                Neighborhood = "Vila Ol�mpia",
                                City = "Sorocaba",
                                StateId = 25
                            }
                        },
                        new BankAgency
                        {
                            Number = 0356,
                            PhoneNumber = "1530116753",
                            BankId = 6,
                            Email = "agencia0356@caixa.com.br",
                            Address = new Address
                            {
                                Street = "Rua Doutor �lvaro Soares",
                                Number = "516",
                                ZipCode = "	18010190",
                                Neighborhood = "Centro",
                                City = "Sorocaba",
                                StateId = 25
                            }
                        },
                        new BankAgency
                        {
                            Number = 3327,
                            PhoneNumber = "1532341331",
                            BankId = 4,
                            Email = "santanderag3327@santander.com",
                            Address = new Address
                            {
                                Street = "Rua 15 de Novembro",
                                Number = "516",
                                ZipCode = "	18010082",
                                Neighborhood = "Centro",
                                City = "Sorocaba",
                                StateId = 25
                            }
                        }
                    };

                context.BankAgencies.AddRange(banksAgencies);
            }

            if (!context.ProviderBankAccounts.Any())
            {
                var providersBankAccount = new Collection<ProviderBankAccount>
                {
                    new ProviderBankAccount { Number = "12328510", BankAgencyId = 1, ProviderId = 1, ModuleId = 4, ApplicationUserId = 1 },
                    new ProviderBankAccount { Number = "19738809", BankAgencyId = 3, ProviderId = 2, ModuleId = 4, ApplicationUserId = 1 },
                    new ProviderBankAccount { Number = "14581022", BankAgencyId = 2, ProviderId = 3, ModuleId = 4, ApplicationUserId = 1 },
                    new ProviderBankAccount { Number = "10280804", BankAgencyId = 2, ProviderId = 4, ModuleId = 4, ApplicationUserId = 1 },
                    new ProviderBankAccount { Number = "639490", BankAgencyId = 1, ProviderId = 5, ModuleId = 4, ApplicationUserId = 1 },
                    new ProviderBankAccount { Number = "353355112", BankAgencyId = 1, ProviderId = 6, ModuleId = 4, ApplicationUserId = 1 },
                    new ProviderBankAccount { Number = "007132940480", BankAgencyId = 4, ProviderId = 7, ModuleId = 4, ApplicationUserId = 1 },
                    new ProviderBankAccount { Number = "12942065", BankAgencyId = 1, ProviderId = 8, ModuleId = 4, ApplicationUserId = 1 }
                };

                context.ProviderBankAccounts.AddRange(providersBankAccount);
            }

            if (!context.InternalBankAccounts.Any())
            {
                var internalBankAccounts = new Collection<InternalBankAccount>
                {
                    new InternalBankAccount { Number = "11941405", BankAgencyId = 1, Balance = 12000, ModuleId = 3, ApplicationUserId = 1 },
                    new InternalBankAccount { Number = "207274", BankAgencyId = 2, Balance = 15500, ModuleId = 3, ApplicationUserId = 1 },
                    new InternalBankAccount { Number = "457214", BankAgencyId = 3, Balance = 134000, ModuleId = 3, ApplicationUserId = 1 }
                };

                context.InternalBankAccounts.AddRange(internalBankAccounts);
            }

            //if (!context.AccountToPays.Any())
            //{
            //    var accountToPays = new Collection<AccountToPay>
            //{
            //    new AccountToPay
            //    {
            //    },
            //    new AccountToPay
            //    {
            //    },
            //    new AccountToPay
            //    {
            //    },
            //    new AccountToPay
            //    {
            //    },
            //};
            //    context.Modules.AddRange(accountToPays);
            //}
        }
    }
}