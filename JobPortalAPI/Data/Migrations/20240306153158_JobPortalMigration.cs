using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortalAPI.Migrations
{
    /// <inheritdoc />
    public partial class JobPortalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JobCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Peson",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peson", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    Accepted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Category_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAddresse",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAddresse", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CompanyAddresse_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: true),
                    ExperienceYears = table.Column<int>(type: "int", nullable: true),
                    WorkSchedule = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Job_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonAddresse",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAddresse", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonAddresse_Peson_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Peson",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PersonLogin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: true),
                    PersonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLogin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonLogin_Peson_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Peson",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobID = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    ResumePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverLetter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Application_Job_JobID",
                        column: x => x.JobID,
                        principalTable: "Job",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application_Peson_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Peson",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobsCategory",
                columns: table => new
                {
                    JobCategoriesID = table.Column<int>(type: "int", nullable: false),
                    JobsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsCategory", x => new { x.JobCategoriesID, x.JobsID });
                    table.ForeignKey(
                        name: "FK_JobsCategory_JobCategory_JobCategoriesID",
                        column: x => x.JobCategoriesID,
                        principalTable: "JobCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobsCategory_Job_JobsID",
                        column: x => x.JobsID,
                        principalTable: "Job",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleSavedJobs",
                columns: table => new
                {
                    SavedJobsID = table.Column<int>(type: "int", nullable: false),
                    peopleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleSavedJobs", x => new { x.SavedJobsID, x.peopleID });
                    table.ForeignKey(
                        name: "FK_PeopleSavedJobs_Job_SavedJobsID",
                        column: x => x.SavedJobsID,
                        principalTable: "Job",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleSavedJobs_Peson_peopleID",
                        column: x => x.peopleID,
                        principalTable: "Peson",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationResponseModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationResponseModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicationResponseModel_Application_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "Application",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_JobID",
                table: "Application",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_Application_PersonID",
                table: "Application",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationResponseModel_ApplicationID",
                table: "ApplicationResponseModel",
                column: "ApplicationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_CompanyID",
                table: "Category",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresse_CompanyID",
                table: "CompanyAddresse",
                column: "CompanyID",
                unique: true,
                filter: "[CompanyID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CompanyID",
                table: "Job",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_JobsCategory_JobsID",
                table: "JobsCategory",
                column: "JobsID");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleSavedJobs_peopleID",
                table: "PeopleSavedJobs",
                column: "peopleID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresse_PersonID",
                table: "PersonAddresse",
                column: "PersonID",
                unique: true,
                filter: "[PersonID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLogin_PersonID",
                table: "PersonLogin",
                column: "PersonID",
                unique: true,
                filter: "[PersonID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationResponseModel");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "CompanyAddresse");

            migrationBuilder.DropTable(
                name: "JobsCategory");

            migrationBuilder.DropTable(
                name: "PeopleSavedJobs");

            migrationBuilder.DropTable(
                name: "PersonAddresse");

            migrationBuilder.DropTable(
                name: "PersonLogin");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "JobCategory");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Peson");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
