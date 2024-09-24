using WarehauseApiGraphql.Models;

namespace WarehauseApiGraphql.Query
    {
    public class Query
        {
        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<BazaFv> GetBazaFvs([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.BazaFvs;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Dostawca> GetDostawcy([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.Dostawcas;
            }
        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<FakturaNew> GetFakturaNews([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.FakturaNews;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Fv> GetFvs([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.Fvs;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Klucze> GetKluczes([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.Kluczes;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Kontrahenci> GetKontrahencis([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.Kontrahencis;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<NumerFv> GetNumerFvs([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.NumerFvs;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Odbiorca> GetOdbiorcas([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.Odbiorcas;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<OwnPurchase> GetOwnPurchases([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.OwnPurchases;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<RaportDobowy> GetRaportDobowies([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.RaportDobowies;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<RaportMiesiac> GetRaportMiesiacs([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.RaportMiesiacs;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<RaportRoczny> GetRaportRocznies([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.RaportRocznies;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Sprzedaz> GetSprzedazs([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.Sprzedazs;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Stan> GetStans([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.Stans;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<StawkiVat> GetStawkiVats([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.StawkiVats;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.Users;
            }

        [UseDbContext(typeof(BsdnetphMatgazynMainContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Wystawca> GetWystawcas([ScopedService] BsdnetphMatgazynMainContext context)
            {
            return context.Wystawcas;
            }
        }
    }
