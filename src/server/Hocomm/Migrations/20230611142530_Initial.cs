using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hocomm.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    City = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ZipCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    HomeNr = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    FlatNr = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Nip = table.Column<int>(type: "integer", nullable: false),
                    CompanyType = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HousingCommunities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingCommunities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HousingCommunities_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternalMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Message = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    HousingCommunityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalMessages_HousingCommunities_HousingCommunityId",
                        column: x => x.HousingCommunityId,
                        principalTable: "HousingCommunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    HousingCommunityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_HousingCommunities_HousingCommunityId",
                        column: x => x.HousingCommunityId,
                        principalTable: "HousingCommunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Announcements_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostInvoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    InvoinceNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DueTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GrossValue = table.Column<double>(type: "double precision", nullable: false),
                    NetValue = table.Column<double>(type: "double precision", nullable: false),
                    VatValue = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uuid", nullable: false),
                    HousingCommunityId = table.Column<Guid>(type: "uuid", nullable: false),
                    IssuedByCompanyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostInvoices_Companies_IssuedByCompanyId",
                        column: x => x.IssuedByCompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostInvoices_HousingCommunities_HousingCommunityId",
                        column: x => x.HousingCommunityId,
                        principalTable: "HousingCommunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostInvoices_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostInvoices_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostOthers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    InvoinceNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GrossValue = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uuid", nullable: false),
                    HousingCommunityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostOthers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostOthers_HousingCommunities_HousingCommunityId",
                        column: x => x.HousingCommunityId,
                        principalTable: "HousingCommunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostOthers_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostOthers_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvidenceItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Nr = table.Column<string>(type: "text", nullable: false),
                    FloorNr = table.Column<int>(type: "integer", nullable: false),
                    ShortDescription = table.Column<string>(type: "text", nullable: false),
                    Area = table.Column<double>(type: "double precision", nullable: false),
                    PersonCount = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    HousingCommunityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidenceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvidenceItems_HousingCommunities_HousingCommunityId",
                        column: x => x.HousingCommunityId,
                        principalTable: "HousingCommunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvidenceItems_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvidenceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ShortDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    HousingCommunityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidenceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvidenceTypes_HousingCommunities_HousingCommunityId",
                        column: x => x.HousingCommunityId,
                        principalTable: "HousingCommunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvidenceTypes_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FailureReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    FinishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FromUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    HousingCommunityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FailureReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FailureReports_HousingCommunities_HousingCommunityId",
                        column: x => x.HousingCommunityId,
                        principalTable: "HousingCommunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FailureReports_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HousingCommunityUser",
                columns: table => new
                {
                    HousingCommunitiesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingCommunityUser", x => new { x.HousingCommunitiesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_HousingCommunityUser_HousingCommunities_HousingCommunitiesId",
                        column: x => x.HousingCommunitiesId,
                        principalTable: "HousingCommunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HousingCommunityUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resolutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    HousingCommunityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resolutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resolutions_HousingCommunities_HousingCommunityId",
                        column: x => x.HousingCommunityId,
                        principalTable: "HousingCommunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resolutions_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleMember_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternalMessageConnections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    InternalMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    FromUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ToUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecievedByUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalMessageConnections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalMessageConnections_InternalMessages_InternalMessage~",
                        column: x => x.InternalMessageId,
                        principalTable: "InternalMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalMessageConnections_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalMessageConnections_Users_RecievedByUserId",
                        column: x => x.RecievedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalMessageConnections_Users_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EventDateFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EvendDateTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsRecurrent = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    ValidFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Monday = table.Column<bool>(type: "boolean", nullable: true),
                    Tuesday = table.Column<bool>(type: "boolean", nullable: true),
                    Wednesday = table.Column<bool>(type: "boolean", nullable: true),
                    Thursday = table.Column<bool>(type: "boolean", nullable: true),
                    Friday = table.Column<bool>(type: "boolean", nullable: true),
                    Saturday = table.Column<bool>(type: "boolean", nullable: true),
                    Sunday = table.Column<bool>(type: "boolean", nullable: true),
                    EveryWeek = table.Column<bool>(type: "boolean", nullable: true),
                    EveryMonth = table.Column<bool>(type: "boolean", nullable: true),
                    EveryYear = table.Column<bool>(type: "boolean", nullable: true),
                    HousingCommunityId = table.Column<Guid>(type: "uuid", nullable: false),
                    EvidenceItemId = table.Column<Guid>(type: "uuid", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarEvent_EvidenceItems_EvidenceItemId",
                        column: x => x.EvidenceItemId,
                        principalTable: "EvidenceItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CalendarEvent_HousingCommunities_HousingCommunityId",
                        column: x => x.HousingCommunityId,
                        principalTable: "HousingCommunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarEvent_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvidenceFees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    FeeNr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PaidTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uuid", nullable: false),
                    EvidenceItemId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidenceFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvidenceFees_EvidenceItems_EvidenceItemId",
                        column: x => x.EvidenceItemId,
                        principalTable: "EvidenceItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvidenceFees_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvidenceFees_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvidenceItemMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    EvidenceItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentEvidenceItemId = table.Column<Guid>(type: "uuid", nullable: true),
                    HousingCommunityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidenceItemMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvidenceItemMembers_EvidenceItems_EvidenceItemId",
                        column: x => x.EvidenceItemId,
                        principalTable: "EvidenceItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvidenceItemMembers_EvidenceItems_ParentEvidenceItemId",
                        column: x => x.ParentEvidenceItemId,
                        principalTable: "EvidenceItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvidenceItemMembers_HousingCommunities_HousingCommunityId",
                        column: x => x.HousingCommunityId,
                        principalTable: "HousingCommunities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvidenceItemMembers_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvidenceItemMembers_Users_OwnedByUserId",
                        column: x => x.OwnedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMeterTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UnitType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    HousingCommunityId = table.Column<Guid>(type: "uuid", nullable: false),
                    EvidenceItemId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeterTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMeterTypes_EvidenceItems_EvidenceItemId",
                        column: x => x.EvidenceItemId,
                        principalTable: "EvidenceItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMeterTypes_HousingCommunities_HousingCommunityId",
                        column: x => x.HousingCommunityId,
                        principalTable: "HousingCommunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FailureReportAttachements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Path = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    FailureReportId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FailureReportAttachements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FailureReportAttachements_FailureReports_FailureReportId",
                        column: x => x.FailureReportId,
                        principalTable: "FailureReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FailureReportAttachements_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FailureReportComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Message = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    FromUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FailureReportId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FailureReportComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FailureReportComments_FailureReports_FailureReportId",
                        column: x => x.FailureReportId,
                        principalTable: "FailureReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FailureReportComments_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResolutionVote",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResolutionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResolutionVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResolutionVote_Resolutions_ResolutionId",
                        column: x => x.ResolutionId,
                        principalTable: "Resolutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResolutionVote_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarEventMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    CalendarEventId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEventMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarEventMember_CalendarEvent_CalendarEventId",
                        column: x => x.CalendarEventId,
                        principalTable: "CalendarEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarEventMember_Users_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvidenceFeeItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GrossValue = table.Column<double>(type: "double precision", nullable: false),
                    EvidenceFeeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidenceFeeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvidenceFeeItems_EvidenceFees_EvidenceFeeId",
                        column: x => x.EvidenceFeeId,
                        principalTable: "EvidenceFees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMeters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    EvidenceItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserMeterTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    HousingCommunityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMeters_EvidenceItems_EvidenceItemId",
                        column: x => x.EvidenceItemId,
                        principalTable: "EvidenceItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMeters_HousingCommunities_HousingCommunityId",
                        column: x => x.HousingCommunityId,
                        principalTable: "HousingCommunities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMeters_UserMeterTypes_UserMeterTypeId",
                        column: x => x.UserMeterTypeId,
                        principalTable: "UserMeterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMeters_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AuthorId",
                table: "Announcements",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_HousingCommunityId",
                table: "Announcements",
                column: "HousingCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvent_AuthorId",
                table: "CalendarEvent",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvent_EvidenceItemId",
                table: "CalendarEvent",
                column: "EvidenceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvent_HousingCommunityId",
                table: "CalendarEvent",
                column: "HousingCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEventMember_CalendarEventId",
                table: "CalendarEventMember",
                column: "CalendarEventId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEventMember_MemberId",
                table: "CalendarEventMember",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId",
                table: "Companies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CostInvoices_CreatedById",
                table: "CostInvoices",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CostInvoices_HousingCommunityId",
                table: "CostInvoices",
                column: "HousingCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_CostInvoices_IssuedByCompanyId",
                table: "CostInvoices",
                column: "IssuedByCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CostInvoices_ModifiedById",
                table: "CostInvoices",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_CostOthers_CreatedById",
                table: "CostOthers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CostOthers_HousingCommunityId",
                table: "CostOthers",
                column: "HousingCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_CostOthers_ModifiedById",
                table: "CostOthers",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceFeeItems_EvidenceFeeId",
                table: "EvidenceFeeItems",
                column: "EvidenceFeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceFees_CreatedById",
                table: "EvidenceFees",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceFees_EvidenceItemId",
                table: "EvidenceFees",
                column: "EvidenceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceFees_ModifiedById",
                table: "EvidenceFees",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceItemMembers_CreatedByUserId",
                table: "EvidenceItemMembers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceItemMembers_EvidenceItemId",
                table: "EvidenceItemMembers",
                column: "EvidenceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceItemMembers_HousingCommunityId",
                table: "EvidenceItemMembers",
                column: "HousingCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceItemMembers_OwnedByUserId",
                table: "EvidenceItemMembers",
                column: "OwnedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceItemMembers_ParentEvidenceItemId",
                table: "EvidenceItemMembers",
                column: "ParentEvidenceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceItems_CreatedByUserId",
                table: "EvidenceItems",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceItems_HousingCommunityId",
                table: "EvidenceItems",
                column: "HousingCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceTypes_CreatedByUserId",
                table: "EvidenceTypes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceTypes_HousingCommunityId",
                table: "EvidenceTypes",
                column: "HousingCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_FailureReportAttachements_CreatedById",
                table: "FailureReportAttachements",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FailureReportAttachements_FailureReportId",
                table: "FailureReportAttachements",
                column: "FailureReportId");

            migrationBuilder.CreateIndex(
                name: "IX_FailureReportComments_FailureReportId",
                table: "FailureReportComments",
                column: "FailureReportId");

            migrationBuilder.CreateIndex(
                name: "IX_FailureReportComments_FromUserId",
                table: "FailureReportComments",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FailureReports_FromUserId",
                table: "FailureReports",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FailureReports_HousingCommunityId",
                table: "FailureReports",
                column: "HousingCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_HousingCommunities_AddressId",
                table: "HousingCommunities",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_HousingCommunityUser_UsersId",
                table: "HousingCommunityUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalMessageConnections_FromUserId",
                table: "InternalMessageConnections",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalMessageConnections_InternalMessageId",
                table: "InternalMessageConnections",
                column: "InternalMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalMessageConnections_RecievedByUserId",
                table: "InternalMessageConnections",
                column: "RecievedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalMessageConnections_ToUserId",
                table: "InternalMessageConnections",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalMessages_HousingCommunityId",
                table: "InternalMessages",
                column: "HousingCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Resolutions_CreatedById",
                table: "Resolutions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Resolutions_HousingCommunityId",
                table: "Resolutions",
                column: "HousingCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_ResolutionVote_AuthorId",
                table: "ResolutionVote",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResolutionVote_ResolutionId",
                table: "ResolutionVote",
                column: "ResolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeters_CreatedById",
                table: "UserMeters",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeters_EvidenceItemId",
                table: "UserMeters",
                column: "EvidenceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeters_HousingCommunityId",
                table: "UserMeters",
                column: "HousingCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeters_UserMeterTypeId",
                table: "UserMeters",
                column: "UserMeterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeterTypes_EvidenceItemId",
                table: "UserMeterTypes",
                column: "EvidenceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeterTypes_HousingCommunityId",
                table: "UserMeterTypes",
                column: "HousingCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMember_UserId",
                table: "UserRoleMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "CalendarEventMember");

            migrationBuilder.DropTable(
                name: "CostInvoices");

            migrationBuilder.DropTable(
                name: "CostOthers");

            migrationBuilder.DropTable(
                name: "EvidenceFeeItems");

            migrationBuilder.DropTable(
                name: "EvidenceItemMembers");

            migrationBuilder.DropTable(
                name: "EvidenceTypes");

            migrationBuilder.DropTable(
                name: "FailureReportAttachements");

            migrationBuilder.DropTable(
                name: "FailureReportComments");

            migrationBuilder.DropTable(
                name: "HousingCommunityUser");

            migrationBuilder.DropTable(
                name: "InternalMessageConnections");

            migrationBuilder.DropTable(
                name: "ResolutionVote");

            migrationBuilder.DropTable(
                name: "UserMeters");

            migrationBuilder.DropTable(
                name: "UserRoleMember");

            migrationBuilder.DropTable(
                name: "CalendarEvent");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "EvidenceFees");

            migrationBuilder.DropTable(
                name: "FailureReports");

            migrationBuilder.DropTable(
                name: "InternalMessages");

            migrationBuilder.DropTable(
                name: "Resolutions");

            migrationBuilder.DropTable(
                name: "UserMeterTypes");

            migrationBuilder.DropTable(
                name: "EvidenceItems");

            migrationBuilder.DropTable(
                name: "HousingCommunities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
