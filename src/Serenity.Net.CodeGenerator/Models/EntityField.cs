namespace Serenity.CodeGenerator;

public class EntityField
{
    public string FieldType { get; set; }
    public string DataType { get; set; }
    public string TSType { get; set; }
    public string PropertyName { get; set; }
    public string Ident => PropertyName;
    public bool OmitInGrid { get; set; }
    public bool OmitInForm { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public List<AttributeTypeRef> FlagList { get; } = [];
    public string Flags { get => FlagList == null ? null : string.Join(", ", FlagList.Select(x => x.ToString(new CodeWriter { IsCSharp = true }))); }
    public string PKSchema { get; set; }
    public string PKTable { get; set; }
    public string PKColumn { get; set; }
    public string ForeignJoinAlias { get; set; }
    public bool IsValueType { get; set; }
    public int? Size { get; set; }
    public int Scale { get; set; }
    public string TextualField { get; set; }
    public List<AttributeTypeRef> AttributeList { get; } = [];
    public string Attributes => string.Join(", ", AttributeList.Select(x => x.ToString(new CodeWriter { IsCSharp = true })));
    public List<AttributeTypeRef> ColAttributeList { get; } = [];
    public string ColAttributes => string.Join(", ", ColAttributeList.Select(x => x.ToString(new CodeWriter { IsCSharp = true })));
    public string Expression { get; set; }

    public string TSEditorType
    {
        get
        {
            return FieldType switch
            {
                "Int32" or "Int16" or "Int64" => "IntegerEditor",
                "Single" or "Double" or "Decimal" => "DecimalEditor",
                "DateOnly" or "DateTime" => "DateEditor",
                "Boolean" => "BooleanEditor",
                _ => "StringEditor",
            };
        }
    }

    public string PropertyType
    {
        get { return IsValueType ? DataType + "?" : DataType; }
    }
}