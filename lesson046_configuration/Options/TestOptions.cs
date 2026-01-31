public class TestOptions
{
    public string opt_key1 { get; set; } = string.Empty;
    public SubTestOptions? opt_key2 { get; set; }
}

public class SubTestOptions
{
    public string k1 { get; set; } = string.Empty;
    public string k2 { get; set; } = string.Empty;
}