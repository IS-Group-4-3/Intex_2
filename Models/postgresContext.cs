using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Intex_2.Models
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apr2018> Apr2018s { get; set; }
        public virtual DbSet<BiologicalSample> BiologicalSamples { get; set; }
        public virtual DbSet<C14Datum> C14Data { get; set; }
        public virtual DbSet<Cranial2002> Cranial2002s { get; set; }
        public virtual DbSet<FieldAdultChild> FieldAdultChildren { get; set; }
        public virtual DbSet<FieldAgeCode> FieldAgeCodes { get; set; }
        public virtual DbSet<FieldBurialWrapping> FieldBurialWrappings { get; set; }
        public virtual DbSet<FieldGenderCode> FieldGenderCodes { get; set; }
        public virtual DbSet<FieldHairColor> FieldHairColors { get; set; }
        public virtual DbSet<FieldLocation> FieldLocations { get; set; }
        public virtual DbSet<FieldMain> FieldMains { get; set; }
        public virtual DbSet<FileRecord> FileRecords { get; set; }
        public virtual DbSet<GamousBiologicalSample> GamousBiologicalSamples { get; set; }
        public virtual DbSet<GamousBone> GamousBones { get; set; }
        public virtual DbSet<GamousC14> GamousC14s { get; set; }
        public virtual DbSet<GamousCranial> GamousCranials { get; set; }
        public virtual DbSet<GamousDental> GamousDentals { get; set; }
        public virtual DbSet<GamousLocation> GamousLocations { get; set; }
        public virtual DbSet<GamousMain> GamousMains { get; set; }
        public virtual DbSet<GamousSample> GamousSamples { get; set; }
        public virtual DbSet<MainTblMdb> MainTblMdbs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=el-gamous.chg4orpssig1.us-east-2.rds.amazonaws.com;Database=postgres;Username=postgres;Password=Intex2group4-3;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Apr2018>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("apr2018");

                entity.Property(e => e.AgeCodeSingle).HasColumnName("age_code_single");

                entity.Property(e => e.AgeSkull2018).HasColumnName("age_skull_2018");

                entity.Property(e => e.AreaHillBurials).HasColumnName("area_hill_burials");

                entity.Property(e => e.BodyAnalysis).HasColumnName("body_analysis");

                entity.Property(e => e.BurialAdultChild).HasColumnName("burial_adult_child");

                entity.Property(e => e.BurialAreaEastOrWest).HasColumnName("burial_area_east_or_west");

                entity.Property(e => e.BurialAreaNorthOrSouth).HasColumnName("burial_area_north_or_south");

                entity.Property(e => e.BurialDepth).HasColumnName("burial_depth");

                entity.Property(e => e.BurialDirection).HasColumnName("burial_direction");

                entity.Property(e => e.BurialDirection1).HasColumnName("burial_direction_1");

                entity.Property(e => e.BurialNumber).HasColumnName("burial_number");

                entity.Property(e => e.BurialPreservation).HasColumnName("burial_preservation");

                entity.Property(e => e.BurialSouthToFeet).HasColumnName("burial_south_to_feet");

                entity.Property(e => e.BurialSouthToHead).HasColumnName("burial_south_to_head");

                entity.Property(e => e.BurialWestToFeet).HasColumnName("burial_west_to_feet");

                entity.Property(e => e.BurialWestToHead).HasColumnName("burial_west_to_head");

                entity.Property(e => e.BurialWrapping).HasColumnName("burial_wrapping");

                entity.Property(e => e.Burialageatdeath).HasColumnName("burialageatdeath");

                entity.Property(e => e.Burialagemethod).HasColumnName("burialagemethod");

                entity.Property(e => e.Burialgendermethod).HasColumnName("burialgendermethod");

                entity.Property(e => e.Burialhaircolor).HasColumnName("burialhaircolor");

                entity.Property(e => e.Burialnors).HasColumnName("burialnors");

                entity.Property(e => e.Burialsampletaken).HasColumnName("burialsampletaken");

                entity.Property(e => e.Burialxeorw).HasColumnName("burialxeorw");

                entity.Property(e => e.ButtonOsteoma).HasColumnName("button_osteoma");

                entity.Property(e => e.ByuSample).HasColumnName("byu_sample");

                entity.Property(e => e.ClusterNum).HasColumnName("cluster_num");

                entity.Property(e => e.CribraOrbitala).HasColumnName("cribra_orbitala");

                entity.Property(e => e.DateExcavated).HasColumnName("date_excavated");

                entity.Property(e => e.DateOnSkull).HasColumnName("date_on_skull");

                entity.Property(e => e.FaceBundle).HasColumnName("face_bundle");

                entity.Property(e => e.FieldBook).HasColumnName("field_book");

                entity.Property(e => e.FieldBookPageNumber).HasColumnName("field_book_page_number");

                entity.Property(e => e.FieldNotes).HasColumnName("field_notes");

                entity.Property(e => e.FieldNotes1).HasColumnName("field_notes_1");

                entity.Property(e => e.FieldNotes10).HasColumnName("field_notes_10");

                entity.Property(e => e.FieldNotes11).HasColumnName("field_notes_11");

                entity.Property(e => e.FieldNotes12).HasColumnName("field_notes_12");

                entity.Property(e => e.FieldNotes13).HasColumnName("field_notes_13");

                entity.Property(e => e.FieldNotes2).HasColumnName("field_notes_2");

                entity.Property(e => e.FieldNotes3).HasColumnName("field_notes_3");

                entity.Property(e => e.FieldNotes4).HasColumnName("field_notes_4");

                entity.Property(e => e.FieldNotes5).HasColumnName("field_notes_5");

                entity.Property(e => e.FieldNotes6).HasColumnName("field_notes_6");

                entity.Property(e => e.FieldNotes7).HasColumnName("field_notes_7");

                entity.Property(e => e.FieldNotes8).HasColumnName("field_notes_8");

                entity.Property(e => e.FieldNotes9).HasColumnName("field_notes_9");

                entity.Property(e => e.GenderCode).HasColumnName("gender_code");

                entity.Property(e => e.Goods).HasColumnName("goods");

                entity.Property(e => e.HairColorCode).HasColumnName("hair_color_code");

                entity.Property(e => e.InitialsOfDataEntryChecker).HasColumnName("initials_of_data_entry_checker");

                entity.Property(e => e.InitialsOfDataEntryExpert).HasColumnName("initials_of_data_entry_expert");

                entity.Property(e => e.LengthCm).HasColumnName("length_cm");

                entity.Property(e => e.LengthM).HasColumnName("length_m");

                entity.Property(e => e.LengthOfRemains).HasColumnName("length_of_remains");

                entity.Property(e => e.LinearHypoplasiaEnamel).HasColumnName("linear_hypoplasia_enamel");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.MetopicSuture).HasColumnName("metopic_suture");

                entity.Property(e => e.MonthExcavated).HasColumnName("month_excavated");

                entity.Property(e => e.MonthOnSkull).HasColumnName("month_on_skull");

                entity.Property(e => e.OsteologyNotes).HasColumnName("osteology_notes");

                entity.Property(e => e.OsteologyUnknownComment).HasColumnName("osteology_unknown_comment");

                entity.Property(e => e.PoroticHyperostosis).HasColumnName("porotic_hyperostosis");

                entity.Property(e => e.PoroticHyperostosisLocations).HasColumnName("porotic_hyperostosis_locations");

                entity.Property(e => e.PostcraniaAtMagazine).HasColumnName("postcrania_at_magazine");

                entity.Property(e => e.PostcraniaTrauma).HasColumnName("postcrania_trauma");

                entity.Property(e => e.PostcraniaTrauma1).HasColumnName("postcrania_trauma_1");

                entity.Property(e => e.Rack).HasColumnName("rack");

                entity.Property(e => e.RackAndShelf).HasColumnName("rack_and_shelf");

                entity.Property(e => e.SexSkull2018).HasColumnName("sex_skull_2018");

                entity.Property(e => e.Shelf).HasColumnName("shelf");

                entity.Property(e => e.SkullAtMagazine).HasColumnName("skull_at_magazine");

                entity.Property(e => e.SkullTrauma).HasColumnName("skull_trauma");

                entity.Property(e => e.Square).HasColumnName("square");

                entity.Property(e => e.TemporalMandibularJointOsteoarthritisTmjOa).HasColumnName("temporal_mandibular_joint_osteoarthritis_tmj_oa");

                entity.Property(e => e.ToBeConfirmed).HasColumnName("to_be_confirmed");

                entity.Property(e => e.Tomb).HasColumnName("tomb");

                entity.Property(e => e.YearExcav).HasColumnName("year_excav");

                entity.Property(e => e.YearOnSkull).HasColumnName("year_on_skull");
            });

            modelBuilder.Entity<BiologicalSample>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("biological_samples");

                entity.Property(e => e.BagNumber)
                    .HasMaxLength(1)
                    .HasColumnName("bag_number");

                entity.Property(e => e.BurialLocationEw)
                    .HasMaxLength(3)
                    .HasColumnName("burial_location_ew");

                entity.Property(e => e.BurialLocationNs)
                    .HasMaxLength(3)
                    .HasColumnName("burial_location_ns");

                entity.Property(e => e.BurialNumber)
                    .HasMaxLength(9)
                    .HasColumnName("burial_number");

                entity.Property(e => e.BurialSubplot)
                    .HasMaxLength(6)
                    .HasColumnName("burial_subplot");

                entity.Property(e => e.ClusterNumber).HasColumnName("cluster_number");

                entity.Property(e => e.Date)
                    .HasMaxLength(10)
                    .HasColumnName("date");

                entity.Property(e => e.HighPairEw)
                    .HasMaxLength(6)
                    .HasColumnName("high_pair_ew");

                entity.Property(e => e.HighPairNs)
                    .HasMaxLength(6)
                    .HasColumnName("high_pair_ns");

                entity.Property(e => e.Initials)
                    .HasMaxLength(3)
                    .HasColumnName("initials");

                entity.Property(e => e.LowPairEw)
                    .HasMaxLength(5)
                    .HasColumnName("low_pair_ew");

                entity.Property(e => e.LowPairNs)
                    .HasMaxLength(5)
                    .HasColumnName("low_pair_ns");

                entity.Property(e => e.Notes)
                    .HasMaxLength(97)
                    .HasColumnName("notes");

                entity.Property(e => e.PreviouslySampled)
                    .HasMaxLength(4)
                    .HasColumnName("previously_sampled");

                entity.Property(e => e.RackNumber)
                    .HasMaxLength(10)
                    .HasColumnName("rack_number");
            });

            modelBuilder.Entity<C14Datum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("c14_data");

                entity.Property(e => e.Area).HasColumnName("area");

                entity.Property(e => e.Burial).HasColumnName("burial");

                entity.Property(e => e.C14CalendarDate).HasColumnName("c14_calendar_date");

                entity.Property(e => e.C14Sample2017).HasColumnName("c14_sample_2017");

                entity.Property(e => e.Calibrated95CalendarDateAvg)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("calibrated_95_calendar_date_avg");

                entity.Property(e => e.Calibrated95CalendarDateMax).HasColumnName("calibrated_95_calendar_date_max");

                entity.Property(e => e.Calibrated95CalendarDateMin).HasColumnName("calibrated_95_calendar_date_min");

                entity.Property(e => e.Calibrated95CalendarDateSpan).HasColumnName("calibrated_95_calendar_date_span");

                entity.Property(e => e.Category)
                    .HasMaxLength(14)
                    .HasColumnName("category");

                entity.Property(e => e.Conventional14cAgeBp).HasColumnName("conventional_14c_age_bp");

                entity.Property(e => e.Description)
                    .HasMaxLength(48)
                    .HasColumnName("description");

                entity.Property(e => e.Ew).HasColumnName("ew");

                entity.Property(e => e.Foci).HasColumnName("foci");

                entity.Property(e => e.LocId)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("loc_id");

                entity.Property(e => e.Location)
                    .HasMaxLength(60)
                    .HasColumnName("location");

                entity.Property(e => e.LocationEw)
                    .HasMaxLength(1)
                    .HasColumnName("location_ew");

                entity.Property(e => e.LocationNs)
                    .HasMaxLength(1)
                    .HasColumnName("location_ns");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .HasColumnName("notes");

                entity.Property(e => e.Ns).HasColumnName("ns");

                entity.Property(e => e.Questions)
                    .IsRequired()
                    .HasMaxLength(131)
                    .HasColumnName("questions");

                entity.Property(e => e.Rack).HasColumnName("rack");

                entity.Property(e => e.SizeMl).HasColumnName("size_ml");

                entity.Property(e => e.SomeNumber).HasColumnName("some_number");

                entity.Property(e => e.Square)
                    .HasMaxLength(4)
                    .HasColumnName("square");

                entity.Property(e => e.Tube).HasColumnName("tube");
            });

            modelBuilder.Entity<Cranial2002>(entity =>
            {
                entity.HasKey(e => e.SampleNumber)
                    .HasName("gamous_cranial_pkey");

                entity.ToTable("cranial2002");

                entity.Property(e => e.SampleNumber)
                    .ValueGeneratedNever()
                    .HasColumnName("sample_number");

                entity.Property(e => e.BasionbregmaHeight)
                    .HasPrecision(6, 2)
                    .HasColumnName("basionbregma_height");

                entity.Property(e => e.Basionnasion)
                    .HasPrecision(6, 2)
                    .HasColumnName("basionnasion");

                entity.Property(e => e.BasionprosthionLength)
                    .HasPrecision(6, 2)
                    .HasColumnName("basionprosthion_length");

                entity.Property(e => e.BizygomaticDiameter)
                    .HasPrecision(6, 2)
                    .HasColumnName("bizygomatic_diameter");

                entity.Property(e => e.Bodygender)
                    .HasMaxLength(6)
                    .HasColumnName("bodygender");

                entity.Property(e => e.BurialArtifactDescription)
                    .HasMaxLength(34)
                    .HasColumnName("burial_artifact_description");

                entity.Property(e => e.BurialDepth)
                    .HasPrecision(5, 2)
                    .HasColumnName("burial_depth");

                entity.Property(e => e.BurialNumber).HasColumnName("burial_number");

                entity.Property(e => e.BurialPositioningEastwestDirection)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("burial_positioning_eastwest_direction");

                entity.Property(e => e.BurialPositioningEastwestNumber)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("burial_positioning_eastwest_number");

                entity.Property(e => e.BurialPositioningNorthsouthDirection)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("burial_positioning_northsouth_direction");

                entity.Property(e => e.BurialPositioningNorthsouthNumber)
                    .IsRequired()
                    .HasMaxLength(7)
                    .HasColumnName("burial_positioning_northsouth_number");

                entity.Property(e => e.BurialSubplotDirection)
                    .HasMaxLength(2)
                    .HasColumnName("burial_subplot_direction");

                entity.Property(e => e.BuriedWithArtifacts)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("buried_with_artifacts");

                entity.Property(e => e.Gilesgender)
                    .HasMaxLength(30)
                    .HasColumnName("gilesgender");

                entity.Property(e => e.InterorbitalBreadth)
                    .HasPrecision(5, 2)
                    .HasColumnName("interorbital_breadth");

                entity.Property(e => e.MaximumCranialBreadth)
                    .HasPrecision(6, 2)
                    .HasColumnName("maximum_cranial_breadth");

                entity.Property(e => e.MaximumCranialLength)
                    .HasPrecision(6, 2)
                    .HasColumnName("maximum_cranial_length");

                entity.Property(e => e.MaximumNasalBreadth)
                    .HasPrecision(5, 2)
                    .HasColumnName("maximum_nasal_breadth");

                entity.Property(e => e.Nasionprosthion)
                    .HasPrecision(6, 2)
                    .HasColumnName("nasionprosthion");
            });

            modelBuilder.Entity<FieldAdultChild>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("field_adult_child_pkey");

                entity.ToTable("field_adult_child");

                entity.Property(e => e.Pk)
                    .HasColumnType("character varying")
                    .HasColumnName("pk");

                entity.Property(e => e.Text).HasColumnName("text");
            });

            modelBuilder.Entity<FieldAgeCode>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("field_age_code_pkey");

                entity.ToTable("field_age_code");

                entity.Property(e => e.Pk)
                    .HasColumnType("character varying")
                    .HasColumnName("pk");

                entity.Property(e => e.Text).HasColumnName("text");
            });

            modelBuilder.Entity<FieldBurialWrapping>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("field_burial_wrapping_pkey");

                entity.ToTable("field_burial_wrapping");

                entity.Property(e => e.Pk)
                    .HasColumnType("character varying")
                    .HasColumnName("pk");

                entity.Property(e => e.Text).HasColumnName("text");
            });

            modelBuilder.Entity<FieldGenderCode>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("field_gender_code_pkey");

                entity.ToTable("field_gender_code");

                entity.Property(e => e.Pk)
                    .HasColumnType("character varying")
                    .HasColumnName("pk");

                entity.Property(e => e.Text).HasColumnName("text");
            });

            modelBuilder.Entity<FieldHairColor>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("field_hair_color_pkey");

                entity.ToTable("field_hair_color");

                entity.Property(e => e.Pk)
                    .HasColumnType("character varying")
                    .HasColumnName("pk");

                entity.Property(e => e.Text).HasColumnName("text");
            });

            modelBuilder.Entity<FieldLocation>(entity =>
            {
                entity.ToTable("field_location");

                entity.Property(e => e.BurialAreaEastOrWest).HasColumnName("burial_area_east_or_west");

                entity.Property(e => e.BurialAreaNorthOrSouth).HasColumnName("burial_area_north_or_south");

                entity.Property(e => e.BurialDepth).HasColumnName("burial_depth");

                entity.Property(e => e.BurialDirection).HasColumnName("burial_direction");

                entity.Property(e => e.BurialNumber).HasColumnName("burial_number");

                entity.Property(e => e.BurialSouthToFeet).HasColumnName("burial_south_to_feet");

                entity.Property(e => e.BurialSouthToHead).HasColumnName("burial_south_to_head");

                entity.Property(e => e.BurialWestToFeet).HasColumnName("burial_west_to_feet");

                entity.Property(e => e.BurialWestToHead).HasColumnName("burial_west_to_head");

                entity.Property(e => e.Burialnors).HasColumnName("burialnors");

                entity.Property(e => e.Burialxeorw).HasColumnName("burialxeorw");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Square).HasColumnName("square");
            });

            modelBuilder.Entity<FieldMain>(entity =>
            {
                entity.ToTable("field_main");

                entity.Property(e => e.AgeCode).HasColumnName("age_code");

                entity.Property(e => e.AgeSkull2018).HasColumnName("age_skull_2018");

                entity.Property(e => e.AreaHillBurials).HasColumnName("area_hill_burials");

                entity.Property(e => e.BodyAnalysisYear).HasColumnName("body_analysis_year");

                entity.Property(e => e.BurialAdultChild).HasColumnName("burial_adult_child");

                entity.Property(e => e.BurialAgeAtDeath).HasColumnName("burial_age_at_death");

                entity.Property(e => e.BurialAgeMethod).HasColumnName("burial_age_method");

                entity.Property(e => e.BurialDepth).HasColumnName("burial_depth");

                entity.Property(e => e.BurialGenderMethod).HasColumnName("burial_gender_method");

                entity.Property(e => e.BurialHairColorText).HasColumnName("burial_hair_color_text");

                entity.Property(e => e.BurialPreservation).HasColumnName("burial_preservation");

                entity.Property(e => e.BurialSampleTaken).HasColumnName("burial_sample_taken");

                entity.Property(e => e.BurialWrapping).HasColumnName("burial_wrapping");

                entity.Property(e => e.ButtonOsteoma).HasColumnName("button_osteoma");

                entity.Property(e => e.ByuSample).HasColumnName("byu_sample");

                entity.Property(e => e.ClusterNum).HasColumnName("cluster_num");

                entity.Property(e => e.CribraOrbitala).HasColumnName("cribra_orbitala");

                entity.Property(e => e.DateExcavated).HasColumnName("date_excavated");

                entity.Property(e => e.DateOnSkull).HasColumnName("date_on_skull");

                entity.Property(e => e.FaceBundle).HasColumnName("face_bundle");

                entity.Property(e => e.FieldBook).HasColumnName("field_book");

                entity.Property(e => e.FieldBookPageNumber).HasColumnName("field_book_page_number");

                entity.Property(e => e.FieldNotes).HasColumnName("field_notes");

                entity.Property(e => e.GenderCode).HasColumnName("gender_code");

                entity.Property(e => e.Goods).HasColumnName("goods");

                entity.Property(e => e.HairColorCode).HasColumnName("hair_color_code");

                entity.Property(e => e.InitialsOfDataEntryChecker).HasColumnName("initials_of_data_entry_checker");

                entity.Property(e => e.InitialsOfDataEntryExpert).HasColumnName("initials_of_data_entry_expert");

                entity.Property(e => e.LengthM).HasColumnName("length_m");

                entity.Property(e => e.LengthOfRemains).HasColumnName("length_of_remains");

                entity.Property(e => e.LinearHypoplasiaEnamel).HasColumnName("linear_hypoplasia_enamel");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.MetopicSuture).HasColumnName("metopic_suture");

                entity.Property(e => e.MonthExcavated).HasColumnName("month_excavated");

                entity.Property(e => e.MonthOnSkull).HasColumnName("month_on_skull");

                entity.Property(e => e.OsteologyNotes).HasColumnName("osteology_notes");

                entity.Property(e => e.OsteologyUnknownComment).HasColumnName("osteology_unknown_comment");

                entity.Property(e => e.Picture).HasColumnName("picture");

                entity.Property(e => e.PoroticHyperostosis).HasColumnName("porotic_hyperostosis");

                entity.Property(e => e.PoroticHyperostosisLocations).HasColumnName("porotic_hyperostosis_locations");

                entity.Property(e => e.PostcraniaAtMagazine).HasColumnName("postcrania_at_magazine");

                entity.Property(e => e.PostcraniaTrauma).HasColumnName("postcrania_trauma");

                entity.Property(e => e.PostcraniaTrauma1).HasColumnName("postcrania_trauma_1");

                entity.Property(e => e.Rack).HasColumnName("rack");

                entity.Property(e => e.RackAndShelf).HasColumnName("rack_and_shelf");

                entity.Property(e => e.SexSkull2018).HasColumnName("sex_skull_2018");

                entity.Property(e => e.Shelf).HasColumnName("shelf");

                entity.Property(e => e.SkullAtMagazine).HasColumnName("skull_at_magazine");

                entity.Property(e => e.SkullTrauma).HasColumnName("skull_trauma");

                entity.Property(e => e.TemporalMandibularJointOsteoarthritisTmjOa).HasColumnName("temporal_mandibular_joint_osteoarthritis_tmj_oa");

                entity.Property(e => e.ToBeConfirmed).HasColumnName("to_be_confirmed");

                entity.Property(e => e.Tomb).HasColumnName("tomb");

                entity.Property(e => e.YearExcavated).HasColumnName("year_excavated");

                entity.Property(e => e.YearOnSkull).HasColumnName("year_on_skull");
            });

            modelBuilder.Entity<FileRecord>(entity =>
            {
                entity.ToTable("file_records");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Url).HasColumnName("URL");
            });

            modelBuilder.Entity<GamousBiologicalSample>(entity =>
            {


                entity.ToTable("gamous_biological_samples");

                entity.Property(e => e.BagNumber)
                    .HasMaxLength(1)
                    .HasColumnName("bag_number");

                entity.Property(e => e.BurialLocationEw)
                    .HasMaxLength(3)
                    .HasColumnName("burial_location_ew");

                entity.Property(e => e.BurialLocationNs)
                    .HasMaxLength(3)
                    .HasColumnName("burial_location_ns");

                entity.Property(e => e.BurialNumber)
                    .HasMaxLength(9)
                    .HasColumnName("burial_number");

                entity.Property(e => e.BurialSubplot)
                    .HasMaxLength(6)
                    .HasColumnName("burial_subplot");

                entity.Property(e => e.ClusterNumber).HasColumnName("cluster_number");

                entity.Property(e => e.Date)
                    .HasMaxLength(10)
                    .HasColumnName("date");

                entity.Property(e => e.HighPairEw)
                    .HasMaxLength(6)
                    .HasColumnName("high_pair_ew");

                entity.Property(e => e.HighPairNs)
                    .HasMaxLength(6)
                    .HasColumnName("high_pair_ns");

                entity.Property(e => e.Initials)
                    .HasMaxLength(3)
                    .HasColumnName("initials");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.LowPairEw)
                    .HasMaxLength(5)
                    .HasColumnName("low_pair_ew");

                entity.Property(e => e.LowPairNs)
                    .HasMaxLength(5)
                    .HasColumnName("low_pair_ns");

                entity.Property(e => e.Notes)
                    .HasMaxLength(97)
                    .HasColumnName("notes");

                entity.Property(e => e.PreviouslySampled)
                    .HasMaxLength(4)
                    .HasColumnName("previously_sampled");

                entity.Property(e => e.RackNumber)
                    .HasMaxLength(10)
                    .HasColumnName("rack_number");
            });

            modelBuilder.Entity<GamousBone>(entity =>
            {
                entity.HasKey(e => e.Gamous)
                    .HasName("gamous_bones_pkey");

                entity.ToTable("gamous_bones");

                entity.Property(e => e.Gamous)
                    .ValueGeneratedNever()
                    .HasColumnName("gamous");

                entity.Property(e => e.BasilarSuture)
                    .HasMaxLength(6)
                    .HasColumnName("basilar_suture");

                entity.Property(e => e.BasionBregmaHeight)
                    .HasPrecision(6, 2)
                    .HasColumnName("basion_bregma_height");

                entity.Property(e => e.BasionNasion)
                    .HasPrecision(6, 2)
                    .HasColumnName("basion_nasion");

                entity.Property(e => e.BasionProsthionLength)
                    .HasPrecision(5, 2)
                    .HasColumnName("basion_prosthion_length");

                entity.Property(e => e.BizygomaticDiameter)
                    .HasPrecision(6, 2)
                    .HasColumnName("bizygomatic_diameter");

                entity.Property(e => e.BoneLength)
                    .HasMaxLength(30)
                    .HasColumnName("bone_length");

                entity.Property(e => e.CranialSuture)
                    .HasMaxLength(13)
                    .HasColumnName("cranial_suture");

                entity.Property(e => e.DorsalPitting).HasColumnName("dorsal_pitting");

                entity.Property(e => e.FemurDiameter)
                    .HasMaxLength(30)
                    .HasColumnName("femur_diameter");

                entity.Property(e => e.FemurHead)
                    .HasPrecision(5, 2)
                    .HasColumnName("femur_head");

                entity.Property(e => e.FemurLength)
                    .HasPrecision(4, 1)
                    .HasColumnName("femur_length");

                entity.Property(e => e.ForemanMagnum)
                    .HasMaxLength(30)
                    .HasColumnName("foreman_magnum");

                entity.Property(e => e.Gonian).HasColumnName("gonian");

                entity.Property(e => e.Humerus)
                    .HasMaxLength(30)
                    .HasColumnName("humerus");

                entity.Property(e => e.HumerusHead)
                    .HasPrecision(5, 2)
                    .HasColumnName("humerus_head");

                entity.Property(e => e.HumerusLength)
                    .HasPrecision(4, 1)
                    .HasColumnName("humerus_length");

                entity.Property(e => e.IliacCrest)
                    .HasMaxLength(30)
                    .HasColumnName("iliac_crest");

                entity.Property(e => e.InterorbitalBreadth)
                    .HasPrecision(5, 2)
                    .HasColumnName("interorbital_breadth");

                entity.Property(e => e.MaximumCranialBreadth)
                    .HasPrecision(6, 2)
                    .HasColumnName("maximum_cranial_breadth");

                entity.Property(e => e.MaximumCranialLength)
                    .HasPrecision(6, 2)
                    .HasColumnName("maximum_cranial_length");

                entity.Property(e => e.MaximumNasalBreadth)
                    .HasPrecision(5, 2)
                    .HasColumnName("maximum_nasal_breadth");

                entity.Property(e => e.MedialClavicle)
                    .HasMaxLength(30)
                    .HasColumnName("medial_clavicle");

                entity.Property(e => e.MedialIpRamus).HasColumnName("medial_ip_ramus");

                entity.Property(e => e.NasionProsthion)
                    .HasPrecision(5, 2)
                    .HasColumnName("nasion_prosthion");

                entity.Property(e => e.NuchalCrest).HasColumnName("nuchal_crest");

                entity.Property(e => e.OrbitEdge).HasColumnName("orbit_edge");

                entity.Property(e => e.Osteophytosis)
                    .HasMaxLength(8)
                    .HasColumnName("osteophytosis");

                entity.Property(e => e.ParietalBossing).HasColumnName("parietal_bossing");

                entity.Property(e => e.PreaurSulcus).HasColumnName("preaur_sulcus");

                entity.Property(e => e.PubicBone).HasColumnName("pubic_bone");

                entity.Property(e => e.PubicSymphysis)
                    .HasMaxLength(2)
                    .HasColumnName("pubic_symphysis");

                entity.Property(e => e.Robust).HasColumnName("robust");

                entity.Property(e => e.SciaticNotch).HasColumnName("sciatic_notch");

                entity.Property(e => e.SubpubicAngle).HasColumnName("subpubic_angle");

                entity.Property(e => e.SupraorbitalRidges).HasColumnName("supraorbital_ridges");

                entity.Property(e => e.TibiaLength)
                    .HasPrecision(4, 1)
                    .HasColumnName("tibia_length");

                entity.Property(e => e.VentralArc).HasColumnName("ventral_arc");

                entity.Property(e => e.ZygomaticCrest).HasColumnName("zygomatic_crest");
            });

            modelBuilder.Entity<GamousC14>(entity =>
            {

                entity.ToTable("gamous_c14");

                entity.Property(e => e.Area).HasColumnName("area");

                entity.Property(e => e.Burial).HasColumnName("burial");

                entity.Property(e => e.C14CalendarDate).HasColumnName("c14_calendar_date");

                entity.Property(e => e.C14Sample2017).HasColumnName("c14_sample_2017");

                entity.Property(e => e.Calibrated95CalendarDateAvg)
                    .HasMaxLength(8)
                    .HasColumnName("calibrated_95_calendar_date_avg");

                entity.Property(e => e.Calibrated95CalendarDateMax).HasColumnName("calibrated_95_calendar_date_max");

                entity.Property(e => e.Calibrated95CalendarDateMin).HasColumnName("calibrated_95_calendar_date_min");

                entity.Property(e => e.Calibrated95CalendarDateSpan).HasColumnName("calibrated_95_calendar_date_span");

                entity.Property(e => e.Category)
                    .HasMaxLength(14)
                    .HasColumnName("category");

                entity.Property(e => e.Conventional14cAgeBp).HasColumnName("conventional_14c_age_bp");

                entity.Property(e => e.Description)
                    .HasMaxLength(48)
                    .HasColumnName("description");

                entity.Property(e => e.Ew).HasColumnName("ew");

                entity.Property(e => e.Foci).HasColumnName("foci");

                entity.Property(e => e.Location)
                    .HasMaxLength(60)
                    .HasColumnName("location");

                entity.Property(e => e.LocationEw)
                    .HasMaxLength(1)
                    .HasColumnName("location_ew");

                entity.Property(e => e.LocationNs)
                    .HasMaxLength(1)
                    .HasColumnName("location_ns");

                entity.Property(e => e.LoctionId)
                    .HasMaxLength(11)
                    .HasColumnName("loction_id");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .HasColumnName("notes");

                entity.Property(e => e.Ns).HasColumnName("ns");

                entity.Property(e => e.Questions)
                    .HasMaxLength(131)
                    .HasColumnName("questions");

                entity.Property(e => e.Rack).HasColumnName("rack");

                entity.Property(e => e.SizeMl).HasColumnName("size_ml");

                entity.Property(e => e.SomeNumber).HasColumnName("some_number");

                entity.Property(e => e.Square)
                    .HasMaxLength(4)
                    .HasColumnName("square");

                entity.Property(e => e.Tube).HasColumnName("tube");
            });

            modelBuilder.Entity<GamousCranial>(entity =>
            {


                entity.ToTable("gamous_cranial");

                entity.Property(e => e.BasionbregmaHeight)
                    .HasPrecision(6, 2)
                    .HasColumnName("basionbregma_height");

                entity.Property(e => e.Basionnasion)
                    .HasPrecision(6, 2)
                    .HasColumnName("basionnasion");

                entity.Property(e => e.BasionprosthionLength)
                    .HasPrecision(6, 2)
                    .HasColumnName("basionprosthion_length");

                entity.Property(e => e.BizygomaticDiameter)
                    .HasPrecision(6, 2)
                    .HasColumnName("bizygomatic_diameter");

                entity.Property(e => e.Bodygender)
                    .HasMaxLength(6)
                    .HasColumnName("bodygender");

                entity.Property(e => e.BurialArtifactDescription)
                    .HasMaxLength(34)
                    .HasColumnName("burial_artifact_description");

                entity.Property(e => e.BurialDepth)
                    .HasPrecision(5, 2)
                    .HasColumnName("burial_depth");

                entity.Property(e => e.BurialNumber).HasColumnName("burial_number");

                entity.Property(e => e.BurialPositioningEastwestDirection)
                    .HasMaxLength(5)
                    .HasColumnName("burial_positioning_eastwest_direction");

                entity.Property(e => e.BurialPositioningEastwestNumber)
                    .HasMaxLength(5)
                    .HasColumnName("burial_positioning_eastwest_number");

                entity.Property(e => e.BurialPositioningNorthsouthDirection)
                    .HasMaxLength(5)
                    .HasColumnName("burial_positioning_northsouth_direction");

                entity.Property(e => e.BurialPositioningNorthsouthNumber)
                    .HasMaxLength(7)
                    .HasColumnName("burial_positioning_northsouth_number");

                entity.Property(e => e.BurialSubplotDirection)
                    .HasMaxLength(2)
                    .HasColumnName("burial_subplot_direction");

                entity.Property(e => e.BuriedWithArtifacts)
                    .HasMaxLength(5)
                    .HasColumnName("buried_with_artifacts");

                entity.Property(e => e.Gilesgender)
                    .HasMaxLength(30)
                    .HasColumnName("gilesgender");

                entity.Property(e => e.InterorbitalBreadth)
                    .HasPrecision(5, 2)
                    .HasColumnName("interorbital_breadth");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.MaximumCranialBreadth)
                    .HasPrecision(6, 2)
                    .HasColumnName("maximum_cranial_breadth");

                entity.Property(e => e.MaximumCranialLength)
                    .HasPrecision(6, 2)
                    .HasColumnName("maximum_cranial_length");

                entity.Property(e => e.MaximumNasalBreadth)
                    .HasPrecision(5, 2)
                    .HasColumnName("maximum_nasal_breadth");

                entity.Property(e => e.Nasionprosthion)
                    .HasPrecision(6, 2)
                    .HasColumnName("nasionprosthion");

                entity.Property(e => e.SampleNumber).HasColumnName("sample_number");
            });

            modelBuilder.Entity<GamousDental>(entity =>
            {
                entity.HasKey(e => e.Gamous)
                    .HasName("gamous_dental_pkey");

                entity.ToTable("gamous_dental");

                entity.Property(e => e.Gamous)
                    .ValueGeneratedNever()
                    .HasColumnName("gamous");

                entity.Property(e => e.EpiphysealUnion)
                    .HasMaxLength(12)
                    .HasColumnName("epiphyseal_union");

                entity.Property(e => e.PathologyAnomalies)
                    .HasMaxLength(169)
                    .HasColumnName("pathology_anomalies");

                entity.Property(e => e.ToothAttrition)
                    .HasMaxLength(3)
                    .HasColumnName("tooth_attrition");

                entity.Property(e => e.ToothEruption)
                    .HasMaxLength(42)
                    .HasColumnName("tooth_eruption");
            });

            modelBuilder.Entity<GamousLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("gamous_location_pkey");

                entity.ToTable("gamous_location");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.BurialLocationEw)
                    .HasMaxLength(1)
                    .HasColumnName("burial_location_ew");

                entity.Property(e => e.BurialLocationNs)
                    .HasMaxLength(1)
                    .HasColumnName("burial_location_ns");

                entity.Property(e => e.BurialNumber).HasColumnName("burial_number");

                entity.Property(e => e.BurialSubplot)
                    .HasMaxLength(2)
                    .HasColumnName("burial_subplot");

                entity.Property(e => e.EastToFeet).HasColumnName("east_to_feet");

                entity.Property(e => e.EastToHead).HasColumnName("east_to_head");

                entity.Property(e => e.HeadDirection)
                    .HasMaxLength(4)
                    .HasColumnName("head_direction");

                entity.Property(e => e.HighPairEw).HasColumnName("high_pair_ew");

                entity.Property(e => e.HighPairNs).HasColumnName("high_pair_ns");

                entity.Property(e => e.LowPairEw).HasColumnName("low_pair_ew");

                entity.Property(e => e.LowPairNs).HasColumnName("low_pair_ns");

                entity.Property(e => e.SouthToFeet).HasColumnName("south_to_feet");

                entity.Property(e => e.SouthToHead).HasColumnName("south_to_head");
            });

            modelBuilder.Entity<GamousMain>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("gamous_main_pkey");

                entity.ToTable("gamous_main");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.ArtifactFound)
                    .HasMaxLength(5)
                    .HasColumnName("artifact_found");

                entity.Property(e => e.ArtifactsDescription)
                    .HasMaxLength(119)
                    .HasColumnName("artifacts_description");

                entity.Property(e => e.BurialSituationNotes)
                    .HasMaxLength(1092)
                    .HasColumnName("burial_situation_notes");

                entity.Property(e => e.DateFound)
                    .HasColumnType("date")
                    .HasColumnName("date_found");

                entity.Property(e => e.EstimateAge)
                    .HasPrecision(4, 1)
                    .HasColumnName("estimate_age");

                entity.Property(e => e.EstimateLivingStature)
                    .HasPrecision(7, 3)
                    .HasColumnName("estimate_living_stature");

                entity.Property(e => e.EstimateLivingStatureM).HasColumnName("estimate_living_stature_m");

                entity.Property(e => e.Gamous).HasColumnName("gamous");

                entity.Property(e => e.GeFunctionTotal)
                    .HasPrecision(8, 4)
                    .HasColumnName("ge_function_total");

                entity.Property(e => e.GenderBodyCol)
                    .HasMaxLength(12)
                    .HasColumnName("gender_body_col");

                entity.Property(e => e.GenderGe)
                    .HasMaxLength(12)
                    .HasColumnName("gender_ge");

                entity.Property(e => e.HairColor)
                    .HasMaxLength(6)
                    .HasColumnName("hair_color");

                entity.Property(e => e.LengthOfRemains).HasColumnName("length_of_remains");

                entity.Property(e => e.LengthOfRemainsM).HasColumnName("length_of_remains_m");

                entity.Property(e => e.PreservationIndex)
                    .HasMaxLength(3)
                    .HasColumnName("preservation_index");

                entity.Property(e => e.SampleNumber).HasColumnName("sample_number");
            });

            modelBuilder.Entity<GamousSample>(entity =>
            {
                entity.HasKey(e => e.Gamous)
                    .HasName("gamous_samples_pkey");

                entity.ToTable("gamous_samples");

                entity.Property(e => e.Gamous)
                    .ValueGeneratedNever()
                    .HasColumnName("gamous");

                entity.Property(e => e.BoneTaken)
                    .HasMaxLength(5)
                    .HasColumnName("bone_taken");

                entity.Property(e => e.DescriptionOfTaken)
                    .HasMaxLength(94)
                    .HasColumnName("description_of_taken");

                entity.Property(e => e.HairTaken)
                    .HasMaxLength(5)
                    .HasColumnName("hair_taken");

                entity.Property(e => e.SoftTissueTaken)
                    .HasMaxLength(5)
                    .HasColumnName("soft_tissue_taken");

                entity.Property(e => e.TextileTaken)
                    .HasMaxLength(5)
                    .HasColumnName("textile_taken");

                entity.Property(e => e.ToothTaken)
                    .HasMaxLength(5)
                    .HasColumnName("tooth_taken");
            });

            modelBuilder.Entity<MainTblMdb>(entity =>
            {
                entity.HasKey(e => e.Gamous)
                    .HasName("main_tbl_mdb_pkey");

                entity.ToTable("main_tbl_mdb");

                entity.Property(e => e.Gamous).HasColumnName("gamous");

                entity.Property(e => e.ArtifactFound)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("artifact_found");

                entity.Property(e => e.ArtifactsDescription)
                    .HasMaxLength(119)
                    .HasColumnName("artifacts_description");

                entity.Property(e => e.BasilarSuture)
                    .HasMaxLength(6)
                    .HasColumnName("basilar_suture");

                entity.Property(e => e.BasionBregmaHeight)
                    .HasPrecision(6, 2)
                    .HasColumnName("basion_bregma_height");

                entity.Property(e => e.BasionNasion)
                    .HasPrecision(6, 2)
                    .HasColumnName("basion_nasion");

                entity.Property(e => e.BasionProsthionLength)
                    .HasPrecision(5, 2)
                    .HasColumnName("basion_prosthion_length");

                entity.Property(e => e.BizygomaticDiameter)
                    .HasPrecision(6, 2)
                    .HasColumnName("bizygomatic_diameter");

                entity.Property(e => e.BoneLength)
                    .HasMaxLength(30)
                    .HasColumnName("bone_length");

                entity.Property(e => e.BoneTaken)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("bone_taken");

                entity.Property(e => e.BurialDepth)
                    .HasPrecision(4, 1)
                    .HasColumnName("burial_depth");

                entity.Property(e => e.BurialId)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("burial_id");

                entity.Property(e => e.BurialLocationEw)
                    .HasMaxLength(1)
                    .HasColumnName("burial_location_ew");

                entity.Property(e => e.BurialLocationNs)
                    .HasMaxLength(1)
                    .HasColumnName("burial_location_ns");

                entity.Property(e => e.BurialNumber).HasColumnName("burial_number");

                entity.Property(e => e.BurialSituation)
                    .HasMaxLength(1092)
                    .HasColumnName("burial_situation");

                entity.Property(e => e.BurialSubplot)
                    .HasMaxLength(2)
                    .HasColumnName("burial_subplot");

                entity.Property(e => e.CranialSuture)
                    .HasMaxLength(13)
                    .HasColumnName("cranial_suture");

                entity.Property(e => e.DayFound).HasColumnName("day_found");

                entity.Property(e => e.DescriptionOfTaken)
                    .HasMaxLength(94)
                    .HasColumnName("description_of_taken");

                entity.Property(e => e.DorsalPitting).HasColumnName("dorsal_pitting");

                entity.Property(e => e.EastToFeet).HasColumnName("east_to_feet");

                entity.Property(e => e.EastToHead).HasColumnName("east_to_head");

                entity.Property(e => e.EpiphysealUnion)
                    .HasMaxLength(12)
                    .HasColumnName("epiphyseal_union");

                entity.Property(e => e.EstimateAge)
                    .HasPrecision(4, 1)
                    .HasColumnName("estimate_age");

                entity.Property(e => e.EstimateLivingStature)
                    .HasPrecision(7, 3)
                    .HasColumnName("estimate_living_stature");

                entity.Property(e => e.FemurDiameter)
                    .HasMaxLength(30)
                    .HasColumnName("femur_diameter");

                entity.Property(e => e.FemurHead)
                    .HasPrecision(5, 2)
                    .HasColumnName("femur_head");

                entity.Property(e => e.FemurLength)
                    .HasPrecision(4, 1)
                    .HasColumnName("femur_length");

                entity.Property(e => e.ForemanMagnum)
                    .HasMaxLength(30)
                    .HasColumnName("foreman_magnum");

                entity.Property(e => e.GeFunctionTotal)
                    .HasPrecision(8, 4)
                    .HasColumnName("ge_function_total");

                entity.Property(e => e.GenderBodyCol)
                    .HasMaxLength(12)
                    .HasColumnName("gender_body_col");

                entity.Property(e => e.GenderGe)
                    .HasMaxLength(12)
                    .HasColumnName("gender_ge");

                entity.Property(e => e.Gonian).HasColumnName("gonian");

                entity.Property(e => e.HairColor)
                    .HasMaxLength(6)
                    .HasColumnName("hair_color");

                entity.Property(e => e.HairTaken)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("hair_taken");

                entity.Property(e => e.HeadDirection)
                    .HasMaxLength(4)
                    .HasColumnName("head_direction");

                entity.Property(e => e.HighPairEw).HasColumnName("high_pair_ew");

                entity.Property(e => e.HighPairNs).HasColumnName("high_pair_ns");

                entity.Property(e => e.Humerus)
                    .HasMaxLength(30)
                    .HasColumnName("humerus");

                entity.Property(e => e.HumerusHead)
                    .HasPrecision(5, 2)
                    .HasColumnName("humerus_head");

                entity.Property(e => e.HumerusLength)
                    .HasPrecision(4, 1)
                    .HasColumnName("humerus_length");

                entity.Property(e => e.IliacCrest)
                    .HasMaxLength(30)
                    .HasColumnName("iliac_crest");

                entity.Property(e => e.InterorbitalBreadth)
                    .HasPrecision(5, 2)
                    .HasColumnName("interorbital_breadth");

                entity.Property(e => e.LengthOfRemains).HasColumnName("length_of_remains");

                entity.Property(e => e.LowPairEw).HasColumnName("low_pair_ew");

                entity.Property(e => e.LowPairNs).HasColumnName("low_pair_ns");

                entity.Property(e => e.MaximumCranialBreadth)
                    .HasPrecision(6, 2)
                    .HasColumnName("maximum_cranial_breadth");

                entity.Property(e => e.MaximumCranialLength)
                    .HasPrecision(6, 2)
                    .HasColumnName("maximum_cranial_length");

                entity.Property(e => e.MaximumNasalBreadth)
                    .HasPrecision(5, 2)
                    .HasColumnName("maximum_nasal_breadth");

                entity.Property(e => e.MedialClavicle)
                    .HasMaxLength(30)
                    .HasColumnName("medial_clavicle");

                entity.Property(e => e.MedialIpRamus).HasColumnName("medial_ip_ramus");

                entity.Property(e => e.MonthFound)
                    .HasMaxLength(3)
                    .HasColumnName("month_found");

                entity.Property(e => e.NasionProsthion)
                    .HasPrecision(5, 2)
                    .HasColumnName("nasion_prosthion");

                entity.Property(e => e.NuchalCrest).HasColumnName("nuchal_crest");

                entity.Property(e => e.OrbitEdge).HasColumnName("orbit_edge");

                entity.Property(e => e.Osteophytosis)
                    .HasMaxLength(8)
                    .HasColumnName("osteophytosis");

                entity.Property(e => e.ParietalBossing).HasColumnName("parietal_bossing");

                entity.Property(e => e.PathologyAnomalies)
                    .HasMaxLength(169)
                    .HasColumnName("pathology_anomalies");

                entity.Property(e => e.PreaurSulcus).HasColumnName("preaur_sulcus");

                entity.Property(e => e.PreservationIndex)
                    .HasMaxLength(3)
                    .HasColumnName("preservation_index");

                entity.Property(e => e.PubicBone).HasColumnName("pubic_bone");

                entity.Property(e => e.PubicSymphysis)
                    .HasMaxLength(2)
                    .HasColumnName("pubic_symphysis");

                entity.Property(e => e.Robust).HasColumnName("robust");

                entity.Property(e => e.SampleNumber).HasColumnName("sample_number");

                entity.Property(e => e.SciaticNotch).HasColumnName("sciatic_notch");

                entity.Property(e => e.SoftTissueTaken)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("soft_tissue_taken");

                entity.Property(e => e.SouthToFeet).HasColumnName("south_to_feet");

                entity.Property(e => e.SouthToHead).HasColumnName("south_to_head");

                entity.Property(e => e.SubpubicAngle).HasColumnName("subpubic_angle");

                entity.Property(e => e.SupraorbitalRidges).HasColumnName("supraorbital_ridges");

                entity.Property(e => e.TextileTaken)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("textile_taken");

                entity.Property(e => e.TibiaLength)
                    .HasPrecision(4, 1)
                    .HasColumnName("tibia_length");

                entity.Property(e => e.ToothAttrition)
                    .HasMaxLength(3)
                    .HasColumnName("tooth_attrition");

                entity.Property(e => e.ToothEruption)
                    .HasMaxLength(42)
                    .HasColumnName("tooth_eruption");

                entity.Property(e => e.ToothTaken)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("tooth_taken");

                entity.Property(e => e.VentralArc).HasColumnName("ventral_arc");

                entity.Property(e => e.YearFound).HasColumnName("year_found");

                entity.Property(e => e.ZygomaticCrest).HasColumnName("zygomatic_crest");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
