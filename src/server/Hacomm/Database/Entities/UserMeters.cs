using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;

public class UserMeter
{
    //UserMeters
    //id, EvidenceItemId?, housingCommunityId, userMeterTypeId, value, createdAt
    public Guid Id { get; set; }
    public double Value { get; set; }
    public DateTime CreatedAt { get; set; }

    // ref
    public Guid CreatedById { get; set; }
    public User CreatedBy { get; set; } = null!;

    public Guid EvidenceItemId { get; set; }
    public EvidenceItem EvidenceItem { get; set; } = null!;

    public Guid UserMeterTypeId { get; set; }
    public UserMeterType UserMeterType { get; set; } = null!;
}

public class UserMeterType
{
    //UserMeterTypes
    //id, name, unitType, description
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string UnitType { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    // ref

    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;

    public IList<UserMeter> UserMeters { get; set; } = null!;
}
