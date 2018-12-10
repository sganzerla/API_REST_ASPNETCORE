﻿using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.VO;
using System.Threading.Tasks;
using Tapioca.HATEOAS;

namespace RestWithASPNETUdemy.Hypermedia
{
    public class BooksEnrich : ObjectContentResponseEnricher<BookVO>
    {   
        protected override Task EnrichModel(BookVO content, IUrlHelper urlHelper)
        {
            var path = "api/v1/books";
            var url = new { controller = path, content.Id };
            content.Links.Add(new HyperMediaLink() {
                Action=HttpActionVerb.GET,
                Href = urlHelper.Link("DefaultApi",url),
                Rel = RelationType.self,
                Type=ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = urlHelper.Link("DefaultApi", url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = urlHelper.Link("DefaultApi", url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = urlHelper.Link("DefaultApi", url),
                Rel = RelationType.self,
                Type = "int"
            });
            return null;
        }
    }
}
