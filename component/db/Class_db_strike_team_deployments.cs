// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Web.UI.WebControls;

namespace Class_db_strike_team_deployments
  {

  public class TClass_db_strike_team_deployments: TClass_db
    {

    private static class Static
      {
      internal const string CATALOG_CMDTEXT = k.EMPTY
      + "select strike_team_deployment.id as id"
      + " , DATE_FORMAT(creation_date,'%Y-%m-%d') as creation_date"
      + " , name"
      + " , IF(MAX(end) < NOW(),'Concluded',IF(MIN(start) < NOW(),'UNDERWAY','*MOBILIZING*')) as status"
      + " from strike_team_deployment"
      +   " left join strike_team_deployment_operational_period on (strike_team_deployment_operational_period.deployment_id=strike_team_deployment.id)"
      + " group by strike_team_deployment.id";
      }

    private class strike_team_deployment_summary
      {
      public string id;
      public DateTime creation_date;
      public string name;
      public string member_policy_id;
      public string member_policy_description;
      }

    private readonly TClass_db_trail db_trail = null;

    public TClass_db_strike_team_deployments() : base()
      {
      db_trail = new TClass_db_trail();
      }

    internal bool BeAllConcludedWithinScope()
      {
      var be_all_concluded_within_scope = false;
      Open();
      using var my_sql_command = new MySqlCommand
        (
        //
        // By bookkending the equality test with the IFNULL(~,1) clause, we cover the case where the catalog is empty.
        //
        "select IFNULL(sum(status = 'Concluded') = count(*),1) from ("+   Static.CATALOG_CMDTEXT + " ) as catalog",
        connection
        ); 
      be_all_concluded_within_scope = ("1" == my_sql_command.ExecuteScalar().ToString());
      Close();
      return be_all_concluded_within_scope;
      }

    internal bool BeAnyOperationalPeriodStartedFor(string deployment_id)
      {
      var be_any_operational_period_started_for = true;
      Open();
      using var my_sql_command = new MySqlCommand("select count(*) from strike_team_deployment_operational_period where deployment_id = '" + deployment_id + "' and start <= NOW()",connection);
      be_any_operational_period_started_for = "0" != my_sql_command.ExecuteScalar().ToString();
      Close();
      return be_any_operational_period_started_for;
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(IFNULL(creation_date,'-'),'|',IFNULL(name,'-'))";
      Open();
      ((target) as ListControl).Items.Clear();
      using var my_sql_command = new MySqlCommand
        (
        "select id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from strike_team_deployment"
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

    internal void BindBaseDataList
      (
      #pragma warning disable CA1801 // Remove unused parameter
      string member_id,
      string sort_order,
      bool be_sort_order_ascending,
      object target
      #pragma warning restore CA1801 // Remove unused parameter
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand(Static.CATALOG_CMDTEXT + " order by creation_date desc",connection);
      ((target) as BaseDataList).DataSource = my_sql_command.ExecuteReader();
      ((target) as BaseDataList).DataBind();
      Close();
      }

    public void BindDirectToListControl(object target)
      {
      Open();
      ((target) as ListControl).Items.Clear();
      using var my_sql_command = new MySqlCommand
        (
        "SELECT id"
        + " , CONVERT(concat(IFNULL(creation_date,'-'),'|',IFNULL(name,'-')) USING utf8) as spec"
        + " FROM strike_team_deployment"
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

    public bool Delete(string id)
      {
      var result = true;
      Open();
      try
        {
        using var my_sql_command = new MySqlCommand(db_trail.Saved("delete from strike_team_deployment where id = \"" + id + "\""), connection);
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
      out DateTime creation_date,
      out string name,
      out string member_policy_id
      )
      {
      creation_date = DateTime.MinValue;
      name = k.EMPTY;
      member_policy_id = k.EMPTY;
      var result = false;
      //
      Open();
      using var my_sql_command = new MySqlCommand("select * from strike_team_deployment where CAST(id AS CHAR) = '" + id + "'", connection);
      var dr = my_sql_command.ExecuteReader();
      if (dr.Read())
        {
        creation_date = DateTime.Parse(dr["creation_date"].ToString());
        name = dr["name"].ToString();
        member_policy_id = dr["member_policy_id"].ToString();
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    internal string IdOf(object summary)
      {
      return (summary as strike_team_deployment_summary).id;
      }

    internal string IdOfPractical
      (
      DateTime creation_date,
      string name
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        ("select id from strike_team_deployment where creation_date = '" + creation_date.ToString("yyyy-MM-dd") + "' and name = '" + name + "'",connection);
      var id_of_practical_obj = my_sql_command.ExecuteScalar();
      Close();
      return (id_of_practical_obj == null ? k.EMPTY : id_of_practical_obj.ToString());
      }

    internal string MemberPolicyDescription(object summary)
      {
      return (summary as strike_team_deployment_summary).member_policy_description;
      }

    internal string MemberPolicyId(object summary)
      {
      return (summary as strike_team_deployment_summary).member_policy_id;
      }

    internal string NameOf(object summary)
      {
      return (summary as strike_team_deployment_summary).name;
      }

    internal string NameOfId(string id)
      {
      Open();
      using var my_sql_command = new MySqlCommand("select name from strike_team_deployment where id = '" + id + "'",connection);
      var name_of_id_obj = my_sql_command.ExecuteScalar();
      Close();
      return (name_of_id_obj == null ? k.EMPTY : name_of_id_obj.ToString());
      }

    public void Set
      (
      string id,
      DateTime creation_date,
      string name,
      string member_policy_id
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "creation_date = '" + creation_date.ToString("yyyy-MM-dd") + "'"
      + " , name = NULLIF('" + name + "','')"
      + " , member_policy_id = NULLIF('" + member_policy_id + "','')"
      + k.EMPTY;
      db_trail.MimicTraditionalInsertOnDuplicateKeyUpdate
        (
        target_table_name:"strike_team_deployment",
        key_field_name:"id",
        key_field_value:id,
        childless_field_assignments_clause:childless_field_assignments_clause
        );
      }

    internal object Summary(string id)
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "SELECT strike_team_deployment.creation_date as creation_date"
        + " , strike_team_deployment.name as name"
        + " , member_policy_id"
        + " , strike_team_deployment_member_policy.description as member_policy_description"
        + " FROM strike_team_deployment"
        +   " join strike_team_deployment_member_policy on (strike_team_deployment_member_policy.id=strike_team_deployment.member_policy_id)"
        + " where strike_team_deployment.id = '" + id + "'",
        connection
        );
      var dr = my_sql_command.ExecuteReader();
      dr.Read();
      var the_summary = new strike_team_deployment_summary()
        {
        id = id,
        creation_date = DateTime.Parse(dr["creation_date"].ToString()),
        name = dr["name"].ToString(),
        member_policy_id = dr["member_policy_id"].ToString(),
        member_policy_description = dr["member_policy_description"].ToString()
        };
      Close();
      return the_summary;
      }

    } // end TClass_db_strike_team_deployments

  }
