using System;
using System.Collections.Generic;

namespace WarehauseApiGraphql.Models;

public partial class Dostawca
{
    public int Id { get; set; }

    public string NrDostawcy { get; set; } = null!;

    public string NazwaDostawcy { get; set; } = null!;

    public string DowodZakupu { get; set; } = null!;

    public string DataZakupu { get; set; } = null!;

    public double Netto23 { get; set; }

    public double Podatek23 { get; set; }

    public int Vat23 { get; set; }

    public double Netto8 { get; set; }

    public double Podatek8 { get; set; }

    public int Vat8 { get; set; }

    public double Netto5 { get; set; }

    public double Podatek5 { get; set; }

    public int Vat5 { get; set; }

    public string Kod1 { get; set; } = null!;

    public string Kod2 { get; set; } = null!;

    public string Kod3 { get; set; } = null!;

    public string Kod4 { get; set; } = null!;

    public string Kod5 { get; set; } = null!;

    public string? NumerZamowienia { get; set; }
}
