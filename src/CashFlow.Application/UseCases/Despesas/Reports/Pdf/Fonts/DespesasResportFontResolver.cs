using PdfSharp.Fonts;

namespace CashFlow.Application.UseCases.Despesas.Reports.Pdf.Fonts;

public class DespesasResportFontResolver: IFontResolver
{
    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
    {
        return new FontResolverInfo(familyName, bold, italic);
    }

    public byte[]? GetFont(string faceName)
    {
        throw new NotImplementedException();
    }
}