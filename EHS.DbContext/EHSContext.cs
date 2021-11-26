using EHS.Entities;
using Microsoft.EntityFrameworkCore;

namespace EHS.DbContexts
{
    public partial class EHSContext : DbContext
    {


        public EHSContext(DbContextOptions<EHSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EhsCourse> EhsCourses { get; set; }
        public virtual DbSet<EhsCoursefolder> EhsCoursefolders { get; set; }
        public virtual DbSet<EhsCoursefoldercourseware> EhsCoursefoldercoursewares { get; set; }
        public virtual DbSet<EhsCoursearrange> EhsCoursearranges { get; set; }
        public virtual DbSet<EhsCourseware> EhsCoursewares { get; set; }
        public virtual DbSet<EhsExam> EhsExams { get; set; }
        public virtual DbSet<EhsExamarrange> EhsExamarranges { get; set; }
        public virtual DbSet<EhsExamquestionscore> EhsExamquestionscores { get; set; }
        public virtual DbSet<EhsExamrecord> EhsExamrecords { get; set; }
        public virtual DbSet<EhsLib> EhsLibs { get; set; }
        public virtual DbSet<EhsOccupationalhazard> EhsOccupationalhazards { get; set; }
        public virtual DbSet<EhsQuestion> EhsQuestions { get; set; }
        public virtual DbSet<EhsStudyrecord> EhsStudyrecords { get; set; }
        public virtual DbSet<EhsStudiedcourseware> EhsStudiedcoursewares {  get; set; }

        /// <summary>
        /// 进一步配置注册映射模型
        /// </summary>
        /// <param name="modelBuilder">用于为该上下文构造模型的构造器</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SCOTT");

            modelBuilder.Entity<EhsCourse>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_COURSE_ID");
                entity.ToTable("EHS_COURSE");

                entity.Property(e => e.Id).UseHiLo("COURSEID")
                    // .HasPrecision(9)

                    .HasColumnName("ID");

                entity.Property(e => e.Classhour)
                    //.HasPrecision(9)

                    .HasColumnName("CLASSHOUR");

                entity.Property(e => e.Context)
                    .IsRequired()
                    .HasMaxLength(150)

                    .HasColumnName("CONTEXT");

                entity.Property(e => e.Coursewarefile)
                    .IsRequired()
                    .HasMaxLength(255)

                    .HasColumnName("COURSEWAREFILE");

                entity.Property(e => e.Createtime)
                    .HasColumnType("DATE")

                    .HasColumnName("CREATETIME");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("NAME");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<EhsCourse1>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_COURSE_ID1");
                entity.ToTable("EHS_COURSE1");

                entity.Property(e => e.Id).UseHiLo("COURSEID1")
                    // .HasPrecision(9)

                    .HasColumnName("ID");

                entity.Property(e => e.Classhour)
                    //.HasPrecision(9)

                    .HasColumnName("CLASSHOUR");

                entity.Property(e => e.Context)
                    .IsRequired()
                    .HasMaxLength(150)

                    .HasColumnName("CONTEXT");

                entity.Property(e => e.Coursewarefile)
                    .IsRequired()
                    .HasMaxLength(255)

                    .HasColumnName("COURSEWAREFILE");

                entity.Property(e => e.Createtime)
                    .HasColumnType("DATE")

                    .HasColumnName("CREATETIME");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("NAME");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<EhsCoursefolder>(entity => {
                entity.HasKey(e => e.Id).HasName("PK_COURSEFOLDER_ID");
                entity.ToTable("EHS_COURSEFOLDER");

                entity.Property(e => e.Id).UseHiLo("COURSEFOLDERID")
                    // .HasPrecision(9)
                    .HasColumnName("ID");

                entity.Property(e => e.Courseid)
                    //.HasPrecision(9)
                    .HasColumnName("COURSEID");
                entity.Property(e => e.Foldername)
                    .HasMaxLength(20)
                    .HasColumnName("FOLDERNAME");
            });

            modelBuilder.Entity<EhsCoursefoldercourseware>(entity => {
                entity.HasKey(e => e.Id).HasName("PK_COURSEFOLDERCOURSEWARE_ID");
                entity.HasIndex(e => e.Courseid).HasDatabaseName("CFCW_COURSEID_IDX");

                entity.ToTable("EHS_COURSEFOLDERCOURSEWARE");

                entity.Property(e => e.Id).UseHiLo("COURSEFOLDERCOURSEWAREID")
                    //.HasPrecision(9)
                    .HasColumnName("ID");

                entity.Property(e => e.Courseid)
                    //.HasPrecision(9)
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Foldeid)
                    //.HasPrecision(9)
                    .HasColumnName("FOLDERID");

                entity.Property(e => e.Courseware)

                    .HasColumnName("COURSEWARE");
            });

            modelBuilder.Entity<EhsCoursearrange>(entity => {
                entity.HasKey(e => e.Id).HasName("PK_COURSEARRANGE_ID");
                entity.ToTable("EHS_COURSEARRANGE");

                entity.Property(e => e.Id).HasColumnName("ID").UseHiLo("COURSEARRANGEID");
                entity.Property(e => e.Courseid)
                    // .HasPrecision(9)
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Badge)
                    // .HasPrecision(9)
                    .HasColumnName("BADGE");

                entity.Property(e => e.Authority)
                    //.HasPrecision(1)
                    .HasColumnName("AUTHORITY");

            });

            modelBuilder.Entity<EhsCourseware>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_COURSEWARE_ID");
                entity.ToTable("EHS_COURSEWARE");

                entity.Property(e => e.Id).UseHiLo("COURSEWAREID")
                    // .HasPrecision(9)
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Starttime)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("STARTTIME");

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("EXTENSION");

                entity.Property(e => e.Capable)
                    .IsRequired()

                    .HasColumnName("CAPABLE");

                entity.Property(e => e.Tag)
                    .HasMaxLength(20)
                    .HasColumnName("TAG");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<EhsExam>(entity =>
            {
                entity.HasKey(e => e.Examname)
                    .HasName("PK_EXAM_EXNAME");

                entity.ToTable("EHS_EXAM");
                entity.Property(e => e.Anhuan)
                     .IsRequired()
                    .HasColumnName("ANHUAN")
                    .HasDefaultValueSql("0 ");
                entity.Property(e => e.Examname)
                    .HasMaxLength(30)
                    .HasColumnName("EXAMNAME");

                entity.Property(e => e.Artifitial)
                    .IsRequired()
                    // .HasPrecision(1)
                    .HasColumnName("ARTIFITIAL")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Endtime)
                    .HasColumnType("DATE")
                    .HasColumnName("ENDTIME");

                entity.Property(e => e.Examfile)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("EXAMFILE");

                entity.Property(e => e.Levels)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("LEVELS");

                entity.Property(e => e.Libname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("LIBNAME");

                entity.Property(e => e.Limitcount)
                    // .HasPrecision(9)
                    .HasColumnName("LIMITCOUNT");

                entity.Property(e => e.Limittime)
                    .IsRequired()
                    //.HasPrecision(1)
                    .HasColumnName("LIMITTIME")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Lsattime)
                    .HasColumnType("INTERVAL DAY(2) TO SECOND(6)")
                    .HasColumnName("LSATTIME");

                entity.Property(e => e.Qualifiedscore)
                    //.HasPrecision(9)
                    .HasColumnName("QUALIFIEDSCORE");

                entity.Property(e => e.Section)
                    // .HasPrecision(9)
                    .HasColumnName("SECTION")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Starttime)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTTIME");

                entity.Property(e => e.Toalscore)
                    //.HasPrecision(9)
                    .HasColumnName("TOALSCORE");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<EhsExamarrange>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_EXAMARRANGE_ID");
                entity.ToTable("EHS_EXAMARRANGE");

                entity.Property(e => e.Id).UseHiLo("EXAMARRANGEID")
                    // .HasPrecision(9)
                    .HasColumnName("ID");

                entity.Property(e => e.Authority)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("AUTHORITY");

                entity.Property(e => e.Badge)
                    //.HasPrecision(9)

                    .HasColumnName("BADGE");

                entity.Property(e => e.Department)
                    .HasMaxLength(20)

                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.Examname)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("EXAMNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)

                    .HasColumnName("PASSWORD");
            });

            modelBuilder.Entity<EhsExamquestionscore>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_EXAMQUESTIONSCORE_ID");

                entity.ToTable("EHS_EXAMQUESTIONSCORE");

                entity.Property(e => e.Examname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("EXAMNAME");

                entity.Property(e => e.Id).UseHiLo("EXAMQUESTIONSCOREID")
                    //.HasPrecision(9)
                    .HasColumnName("ID");

                entity.Property(e => e.Questionid)
                    // .HasPrecision(9)
                    .HasColumnName("QUESTIONID");

                entity.Property(e => e.Questionscore)
                    // .HasPrecision(9)
                    .HasColumnName("QUESTIONSCORE");
            });

            modelBuilder.Entity<EhsExamrecord>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_EXAMRECORD_ID");
                entity.ToTable("EHS_EXAMRECORD");

                entity.Property(e => e.Id).UseHiLo("EXAMRECORDID")
                    //.HasPrecision(9)
                    .HasColumnName("ID");

                entity.Property(e => e.Answerpath)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ANSWERPATH");

                entity.Property(e => e.Examname)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("EXAMNAME");

                entity.Property(e => e.Examtime)
                    .HasColumnType("DATE")
                    .HasColumnName("EXAMTIME");

                entity.Property(e => e.Lasttime)
                    .HasColumnType("INTERVAL DAY(2) TO SECOND(6)")
                    .HasColumnName("LASTTIME");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("NAME");

                entity.Property(e => e.Objectivescore)
                    //.HasPrecision(9)

                    .HasColumnName("OBJECTIVESCORE");

                entity.Property(e => e.Score)
                    // .HasPrecision(9)

                    .HasColumnName("SCORE");

                entity.Property(e => e.Qualified)
                    .IsRequired();
                //.HasPrecision(1);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("STATUS");

                entity.Property(e => e.Subjectivescore)
                    //.HasPrecision(9)

                    .HasColumnName("SUBJECTIVESCORE");
                entity.Property(e => e.Badge)
                    .HasColumnName("BADGE");

            });

            modelBuilder.Entity<EhsLib>(entity =>
            {
                entity.HasKey(e => e.Libname)
                    .HasName("PK_LIB_LIBNAME");

                entity.ToTable("EHS_LIB");

                entity.Property(e => e.Libname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("LIBNAME");

                entity.Property(e => e.Createtime)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATETIME");

                entity.Property(e => e.Libsummary)
                    .HasMaxLength(200)
                    .HasColumnName("LIBSUMMARY");

                entity.Property(e => e.Questcount)
                    // .HasPrecision(9)
                    .HasColumnName("QUESTCOUNT");

                entity.Property(e => e.Sectioncount)
                    .HasColumnName("SECTIONCOUNT");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TYPE");

                entity.Property(e => e.Usage)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("USAGE");
            });

            modelBuilder.Entity<EhsOccupationalhazard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_OCCUPATIONALHAZARD_ID");
                entity.ToTable("EHS_OCCUPATIONALHAZARD");

                entity.Property(e => e.Id).UseHiLo("OCCUPATTIONALHAZARDID")
                    //.HasPrecision(9)
                    .HasColumnName("ID");

                entity.Property(e => e.Businessdivision)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("BUSINESSDIVISION");

                entity.Property(e => e.Contraindications)
                    .IsRequired()
                    .HasMaxLength(200)

                    .HasColumnName("CONTRAINDICATIONS");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.Factor)
                    .IsRequired()
                    .HasMaxLength(200)

                    .HasColumnName("FACTOR");

                entity.Property(e => e.Harm)
                    .IsRequired()
                    .HasMaxLength(200)

                    .HasColumnName("HARM");

                entity.Property(e => e.Postion)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("POSTION");

                entity.Property(e => e.Protect)
                    .IsRequired()
                    .HasMaxLength(200)

                    .HasColumnName("PROTECT");
            });

            modelBuilder.Entity<EhsQuestion>(entity =>
            {
                entity.ToTable("EHS_QUESTION");
                entity.HasKey(e => e.Id).HasName("PK_QUESTION_ID");
                entity.Property(e => e.Id)
                    .UseHiLo("QUESTIONID")
                    //.HasPrecision(9)
                    .HasColumnName("ID");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("ANSWER");

                entity.Property(e => e.Belongtolib)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("BELONGTOLIB");

                entity.Property(e => e.Belongtosection)
                    // .HasPrecision(9)

                    .HasColumnName("BELONGTOSECTION")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Levels)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("LEVELS");

                entity.Property(e => e.Optionanalysis)
                    .HasMaxLength(100)

                    .HasColumnName("OPTIONANALYSIS");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)

                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<EhsStudiedcourseware>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_STUDIEDCOURSEWARE_ID");
                entity.ToTable("EHS_STUDIEDCOURSEWARE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseHiLo("STUDYRECORDID");
                entity.Property(e => e.Badge)
                    .IsRequired()
                     .HasColumnName("USERID");
                entity.Property(e => e.Courseid)
                    .IsRequired()
                        .HasColumnName("COURSEID");
                entity.Property(e => e.Coursewareid)
                    .IsRequired()
                    .HasColumnName("COURSEWAREID");
            });

            modelBuilder.Entity<EhsStudyrecord>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_STUDYRECORD_ID");
                entity.ToTable("EHS_STUDYRECORD");

                entity.Property(e => e.Id)
                    // .HasPrecision(9)
                    .HasColumnName("ID").UseHiLo("STUDYRECORDID");
                entity.Property(e => e.Courseid)
                    .IsRequired()
                    //.HasPrecision(9)

                    .HasColumnName("COURSE");


                entity.Property(e => e.Totalcoureseware)
                    // .HasPrecision(9)

                    .HasColumnName("TOTALCOURESEWARE");

                entity.Property(e => e.Updatetime)
                    .HasColumnType("DATE")

                    .HasColumnName("UPDATETIME");

                entity.Property(e => e.Badge)
                    .IsRequired()
                    .HasColumnName("USERID");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}