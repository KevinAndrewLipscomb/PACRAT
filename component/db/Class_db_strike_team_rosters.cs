// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_practitioner_strike_team_details;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace Class_db_strike_team_rosters
  {
  public class TClass_db_strike_team_rosters: TClass_db
    {

    private readonly TClass_db_trail db_trail = null;

    public TClass_db_strike_team_rosters() : base()
      {
      db_trail = new TClass_db_trail();
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(id)";
      Open();
      ((target) as ListControl).Items.Clear();
      using var my_sql_command = new MySqlCommand
        (
        "select id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from strike_team_roster"
        + " where " + concat_clause + " like '%" + partial_spec.ToUpper() + "%'"
        + " order by spec",
        connection
        );
      var dr = my_sql_command.ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["spec"].ToString(), dr["id"].ToString()));
        }
      dr.Close();
      Close();
      return ((target) as ListControl).Items.Count > 0;
      }

    public void BindDirectToListControl(object target)
      {
      Open();
      ((target) as ListControl).Items.Clear();
      using var my_sql_command = new MySqlCommand
        (
        "SELECT id"
        + " , CONVERT(concat(id) USING utf8) as spec"
        + " FROM strike_team_roster"
        + " order by spec",
        connection
        );
      var dr = my_sql_command.ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["spec"].ToString(), dr["id"].ToString()));
        }
      dr.Close();
      Close();
      }

    public void BindBaseDataListByServiceId
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string id
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "select strike_team_roster.id as id"
        + " , IF(" + Class_db_practitioner_strike_team_details_Static.BE_TEXTABLE_EXPRESSION + " and " + TClass_db_practitioner_strike_team_details.BeCredentialedAsMemberExpression() + ",'Y','N') as be_credentialed"
        + " , member.id as practitioner_id"
        + " , last_name"
        + " , first_name"
        + " , middle_initial"
        + " , IFNULL(practitioner_level.id,'') as level_id"
        + " , IFNULL(practitioner_level.short_description,'nocert') as level_short_description"
        + " , IFNULL(LPAD(certification_number,7,'0'),'nocert') as certification_number_for_display"
        + " , IFNULL(DATE_FORMAT(birth_date,'%m/%d/%Y'),'REQUIRED') as birth_date"
        + " , be_birth_date_confirmed"
        + " , IFNULL(email_address,'DESIRED') as email_address"
        + " , IFNULL(practitioner_status.description,'') as practitioner_status_description"
        + " from strike_team_roster"
        +   " join member on (member.id=strike_team_roster.practitioner_id)"
        +   " left join practitioner_level on (practitioner_level.id=member.level_id)"
        +   " join service on (service.id=strike_team_roster.service_id)"
        +   " left join practitioner_status on (practitioner_status.id=member.status_id)"
        +   " left join practitioner_strike_team_detail on (practitioner_strike_team_detail.practitioner_id=member.id)"
        + " where service.id = '" + id + "'"
        + " order by " + sort_order.Replace("%", (be_sort_order_ascending ? " asc" : " desc")),
        connection
        );
      ((target) as BaseDataList).DataSource = my_sql_command.ExecuteReader();
      ((target) as BaseDataList).DataBind();
      (((target) as BaseDataList).DataSource as MySqlDataReader).Close();
      Close();
      }

    public bool Delete(string id)
      {
      var result = true;
      Open();
      try
        {
        using var my_sql_command = new MySqlCommand
          (
          db_trail.Saved
            (
            "delete from strike_team_roster"
            + " where id = '" + id + "'"
            ),
          connection
          );
        my_sql_command.ExecuteNonQuery();
        }
      catch(System.Exception e)
        {
        if (e.Message.StartsWith("Cannot delete or update a parent row: a foreign key constraint fails", true, null))
          {
          result = false;
          }
        else
          {
          throw;
          }
        }
      Close();
      return result;
      }

    public bool Get
      (
      string id,
      out string service_id,
      out string practitioner_id
      )
      {
      service_id = k.EMPTY;
      practitioner_id = k.EMPTY;
      var result = false;
      //
      Open();
      using var my_sql_command = new MySqlCommand("select * from strike_team_roster where CAST(id AS CHAR) = \"" + id + "\"", connection);
      var dr = my_sql_command.ExecuteReader();
      if (dr.Read())
        {
        service_id = dr["service_id"].ToString();
        practitioner_id = dr["practitioner_id"].ToString();
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    public void Set
      (
      string id,
      string service_id,
      string practitioner_id
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "service_id = NULLIF('" + service_id + "','')"
      + " , practitioner_id = NULLIF('" + practitioner_id + "','')"
      + k.EMPTY;
      Open();
      using var my_sql_command = new MySqlCommand
        (
        db_trail.Saved
          (
          "insert strike_team_roster (id,service_id,practitioner_id)"
          + " select NULLIF('" + id + "','') as id"
          + " , NULLIF('" + service_id + "','') as service_id"
          + " , NULLIF('" + practitioner_id + "','') as practitioner_id"
          + " from service"
          + " where service.id = '" + service_id + "'"
          + " on duplicate key update "
          + childless_field_assignments_clause
          ),
        connection
        );
      my_sql_command.ExecuteNonQuery();
      Close();
      }

    internal string SizeOf(string service_id)
      {
      var size_of = k.EMPTY;
      Open();
      using var my_sql_command = new MySqlCommand("select count(id) from strike_team_roster where service_id = '" + service_id + "'",connection);
      size_of = my_sql_command.ExecuteScalar().ToString();
      Close();
      return size_of;
      }

    } // end TClass_db_strike_team_rosters

  }
