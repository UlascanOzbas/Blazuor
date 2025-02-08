namespace Blazuor.Models;

public class BreadcrumbItem
{
	public string Text { get; set; } = "";
	public string Href { get; set; } = "";
	public bool IsCurrentPage { get; set; } = false;
}
