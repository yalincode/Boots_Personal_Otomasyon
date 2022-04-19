using AutoMapper;
using Boots_Personal_Otomasyon.BL.Abstract;
using Boots_Personal_Otomasyon.WEBUI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MVCGrid.Models;
using System.Collections.Generic;
using System.Linq;


namespace Boots_Personal_Otomasyon.WEBUI.Grid
{
    public static class PersonalListGrid
    {
        public static MVCGridBuilder<PersonalVM> PersonalListGridCustumize(IApplicationBuilder app)
        {
            var scope=app.ApplicationServices.CreateScope();
            var personalBusiness= scope.ServiceProvider.GetService<IPersonalBusiness>();
            var mapper= scope.ServiceProvider.GetService<IMapper>();

            ColumnDefaults columnDefaults = new ColumnDefaults()
            {
                EnableSorting = true
            };

            return new MVCGridBuilder<PersonalVM>(columnDefaults).WithAuthorizationType(AuthorizationType.AllowAnonymous).WithSorting(sorting: true, defaultSortColumn: "Id", defaultSortDirection: SortDirection.Dsc).WithPaging(paging: true, itemsPerPage: 10, allowChangePageSize: true, maxItemsPerPage: 100).AddColumns(
                cols =>
                {
                    cols.Add("Id").WithValueExpression(t => t.Id.ToString()).WithAllowChangeVisibility(true);
                    cols.Add("NameAndSurname").WithHeaderText("Adı Soyadı").WithVisibility(true, true).WithValueExpression(t => t.NameAndSurname);
                    cols.Add("Email").WithHeaderText("Email").WithVisibility(true,true).WithValueExpression(t=>t.Email);
                    cols.Add("Phone").WithHeaderText("Telefon").WithVisibility(true,true).WithValueExpression(t=>t.Phone);
                    cols.Add("BirthDate").WithHeaderText("Doğum Tarihi").WithVisibility(true,true).WithValueExpression(t=>t.BirthDate.ToString());
                    cols.Add("IdentifierNumber").WithHeaderText("TC").WithVisibility(true,true).WithValueExpression(t=>t.IdentifierNumber);
                    //Edit yapılan alan
                    cols.Add("Edit").WithValueExpression((i, c) => $"<a href='/personal/{i.Id.ToString()}'>Edit</a>").WithHtmlEncoding(false);
                    
                }).WithRetrieveDataMethod((context) =>
                {
                    QueryOptions options = context.QueryOptions;//context grid bilgilerini verir.
                    int pageIndex = options.PageIndex.Value;
                    int pageSize = options.ItemsPerPage.Value;
                    //int totalCount = 120;

                    List<PersonalVM> list =new List<PersonalVM>();
                    var result=personalBusiness.GetAll().Skip(pageIndex).Take(pageSize).ToList();
                    if (result.Count>0)
                    {
                        foreach (var item in result)
                        {
                            list.Add(mapper.Map<PersonalVM>(item));
                        }
                    }

                    return new QueryResult<PersonalVM>() { Items = list, TotalRecords=list.Count};
                });
        }
    }
}
