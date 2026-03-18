using System.Reflection;
using PdfSharp.Charting;
using PdfSharp.Fonts;

namespace CashFlow.Application.UseCases.Despesas.Reports.Pdf.Fonts;

public class DespesasResportFontResolver: IFontResolver
{
    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
    {
        return new FontResolverInfo(familyName);
    }

    public byte[]? GetFont(string faceName)
    {
        var stream = ReadFontFile(faceName);

        if (stream is null)
        {
            stream = ReadFontFile(FontHelper.DEFAULT_FONT);
        }
        
        var length = stream!.Length;
        
        var data = new byte[length];

        stream.ReadExactly(data);
        
        return data;
    }
    
    private Stream? ReadFontFile(string faceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        return assembly.GetManifestResourceStream($"CashFlow.Application.UseCases.Despesas.Reports.Pdf.Fonts.{faceName}.ttf");
    }
}