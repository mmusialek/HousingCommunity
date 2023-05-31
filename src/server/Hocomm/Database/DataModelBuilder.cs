using Hocomm.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database;
static class DataModelBuilder
{
    private delegate void BuildModelExt(ModelBuilder builder);

    internal static void BuildAll(this ModelBuilder builder)
    {
        builder.UseCollation("en_US.utf8");

        var builderList = new List<BuildModelExt>
        {
            AddressModelBuilder.Build,
            AnnouncementModelBuilder.Build,
            CalendarEventModelBuilder.Build,
            EvidenceItemModelBuilder.Build,
            FailureReportModelBuilder.Build,
            FeeCostsInvoicesModelBuilder.Build,
            HousingCommunityModelBuilder.Build,
            InternalMessageModelBuilder.Build,
            ResolutionModelBuilder.Build,
            UserModelBuilder.Build,
            UserMeterModelBuilder.Build
        };

        foreach (var builderItem in builderList)
        {
            builderItem(builder);
        }
    }
}
