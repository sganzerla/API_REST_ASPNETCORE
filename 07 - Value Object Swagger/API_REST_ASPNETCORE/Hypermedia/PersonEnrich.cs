using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.VO;
using System;
using System.Threading.Tasks;
using Tapioca.HATEOAS;

namespace RestWithASPNETUdemy.Hypermedia
{
    public class PersonEnrich : ObjectContentResponseEnricher<PersonVO>
    {   

        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            var path = "api/v1/persons";
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
