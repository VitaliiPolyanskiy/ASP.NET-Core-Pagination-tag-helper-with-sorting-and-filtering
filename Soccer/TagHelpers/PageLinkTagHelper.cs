using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Soccer.Models;

namespace Soccer.TagHelpers;

public class PageLinkTagHelper(IUrlHelperFactory urlHelperFactory) : TagHelper
{
    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; } = null!;

    public PageViewModel? PageModel { get; set; }
    public string PageAction { get; set; } = "";

    [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
    public Dictionary<string, object> PageUrlValues { get; set; } = [];

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (PageModel is null)
            throw new ArgumentNullException(nameof(PageModel), "Модель сторінки не встановлена");

        IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
        output.TagName = "nav"; 

        TagBuilder tag = new("ul");
        tag.AddCssClass("pagination justify-content-center mt-4");

        if (PageModel.HasPreviousPage)
            tag.InnerHtml.AppendHtml(CreateTag(PageModel.PageNumber - 1, urlHelper));

        tag.InnerHtml.AppendHtml(CreateTag(PageModel.PageNumber, urlHelper));

        if (PageModel.HasNextPage)
            tag.InnerHtml.AppendHtml(CreateTag(PageModel.PageNumber + 1, urlHelper));

        output.Content.AppendHtml(tag);
    }

    private TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
    {
        TagBuilder item = new("li");
        TagBuilder link = new("a");

        if (pageNumber == PageModel?.PageNumber)
        {
            item.AddCssClass("active");
            link.Attributes["aria-current"] = "page";
        }
        else
        {
            PageUrlValues["page"] = pageNumber;
            link.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
        }

        item.AddCssClass("page-item");
        link.AddCssClass("page-link");
        link.InnerHtml.Append(pageNumber.ToString());
        item.InnerHtml.AppendHtml(link);

        return item;
    }
}