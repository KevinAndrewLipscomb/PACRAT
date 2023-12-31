// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace Class_db_strike_team_deployment_assignments
  {
  public class TClass_db_strike_team_deployment_assignments: TClass_db
    {

    private class strike_team_deployment_assignment_summary
      {
      public string id;
      }

    private readonly TClass_db_trail db_trail = null;

    public TClass_db_strike_team_deployment_assignments() : base()
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
        + " from strike_team_deployment_assignment"
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

    public void BindActualsByDeployment
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string deployment_id
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "select strike_team_deployment_assignment.vehicle_id"
        + " , @static_designator := concat(service.name,' ',vehicle.name)"
        + " , @dynamic_designator := IF(IFNULL(tactical_name = @static_designator,TRUE),concat(@static_designator,' (',vehicle_kind.description,')'),concat(IFNULL(tactical_name,''),' [',@static_designator,' (',vehicle_kind.description,')]'))"
        + " , IFNULL(@dynamic_designator,'(none)') as vehicle_designator"
        + " , concat(member.last_name,', ',member.first_name,' (',IFNULL(practitioner_level.short_description,'nocert'),' ',IFNULL(member.certification_number,'nocert'),')') as member_designator"
        + " , member_id"
        + " , prelim_shift_name"
        + " , DATE_FORMAT(start,'%Y-%m-%d %H:%i') as start"
        + " , DATE_FORMAT(end,'%Y-%m-%d %H:%i') as end"
        + " , IF(be_convoy,'YES','no') as be_convoy"
        + " from strike_team_deployment_assignment"
        +   " join strike_team_deployment_operational_period on (strike_team_deployment_operational_period.id=strike_team_deployment_assignment.operational_period_id)"
        +   " left join vehicle on (vehicle.id=strike_team_deployment_assignment.vehicle_id)"
        +   " left join service on (service.id=vehicle.service_id)"
        +   " left join vehicle_kind on (vehicle_kind.id=vehicle.kind_id)"
        +   " left join strike_team_deployment_vehicle on (strike_team_deployment_vehicle.deployment_id=strike_team_deployment_operational_period.deployment_id and strike_team_deployment_vehicle.vehicle_id=vehicle.id)"
        +   " join member on (member.id=strike_team_deployment_assignment.member_id)"
        +   " left join practitioner_level on (practitioner_level.id=member.level_id)"
        + " where strike_team_deployment_operational_period.deployment_id = '" + deployment_id + "'"
        + " order by " + sort_order.Replace("%",(be_sort_order_ascending ? " asc" : " desc")),
        connection
        );
      ((target) as BaseDataList).DataSource = my_sql_command.ExecuteReader();
      ((target) as BaseDataList).DataBind();
      Close();
      }

    public void BindActualsByOperationalPeriod
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string operational_period_id,
      string assignment_level_filter
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "select strike_team_deployment_assignment.vehicle_id"
        + " , @static_designator := concat(service.short_name,' ',vehicle.name)"
        + " , @dynamic_designator := IF(IFNULL(tactical_name = @static_designator,TRUE),concat(@static_designator,' (',vehicle_kind.description,')'),concat(IFNULL(tactical_name,''),' [',@static_designator,' (',vehicle_kind.description,')]'))"
        + " , IFNULL(@dynamic_designator,'(none)') as vehicle_designator"
        + " , concat(member.last_name,', ',member.first_name,' (',IFNULL(practitioner_level.short_description,'nocert'),' ',IFNULL(member.certification_number,'nocert'),')') as member_designator"
        + " , member_id"
        + " from strike_team_deployment_assignment"
        +   " join strike_team_deployment_operational_period on (strike_team_deployment_operational_period.id=strike_team_deployment_assignment.operational_period_id)"
        +   " left join vehicle on (vehicle.id=strike_team_deployment_assignment.vehicle_id)"
        +   " left join service on (service.id=vehicle.service_id)"
        +   " left join vehicle_kind on (vehicle_kind.id=vehicle.kind_id)"
        +   " left join strike_team_deployment_vehicle on (strike_team_deployment_vehicle.deployment_id=strike_team_deployment_operational_period.deployment_id and strike_team_deployment_vehicle.vehicle_id=vehicle.id)"
        +   " join member on (member.id=strike_team_deployment_assignment.member_id)"
        +   " left join practitioner_level on (practitioner_level.id=member.level_id)"
        + " where operational_period_id = '" + operational_period_id + "'"
        +     (assignment_level_filter.Length == 0 ? k.EMPTY : " and vehicle.id is not null")
        + " order by " + sort_order.Replace("%",(be_sort_order_ascending ? " asc" : " desc")),
        connection
        );
      ((target) as BaseDataList).DataSource = my_sql_command.ExecuteReader();
      ((target) as BaseDataList).DataBind();
      Close();
      }

    internal void BindBaseDataList
      (
      #pragma warning disable CA1801 // Remove unused parameter
      string sort_order,
      bool be_sort_order_ascending,
      object target
      #pragma warning restore CA1801 // Remove unused parameter
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "select strike_team_deployment_assignment.id as id"
        + " from strike_team_deployment_assignment",
        connection
        );
      ((target) as BaseDataList).DataSource = my_sql_command.ExecuteReader();
      ((target) as BaseDataList).DataBind();
      Close();
      }

    internal void BindDigestByDeployment
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string deployment_id
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "select *"
        + " , count(member_id) as par"
        + " , '?' as effective_patient_care_level"
        + " , GROUP_CONCAT(strike_team_member_sms_target SEPARATOR ', ') as sms_target"
        + " from"
        +   " ("
        +   " select operational_period_id"
        +   " , vehicle.id as vehicle_id"
        +   " , @static_designator := concat(service.name,' ',vehicle.name)"
        +   " , @dynamic_designator := IF(IFNULL(tactical_name = @static_designator,TRUE),@static_designator,concat(IFNULL(tactical_name,''),' [',@static_designator,']'))"
        +   " , IFNULL(@dynamic_designator,'(none)') as vehicle_designator"
        +   " , vehicle_kind.description as kind"
        +   " , patient_care_level.description as vehicle_patient_care_level_description"
        +   " , member_id"
        +   " , IFNULL(practitioner_level.short_description,'nocert') as max_practitioner_level_short_description"
        +   " , concat(phone_number,'@',hostname) as strike_team_member_sms_target"
        +   " , prelim_shift_name"
        +   " , DATE_FORMAT(start,'%Y-%m-%d %H:%i') as start"
        +   " , DATE_FORMAT(end,'%Y-%m-%d %H:%i') as end"
        +   " , IF(be_convoy,'YES','no') as be_convoy"
        +   " from strike_team_deployment_assignment"
        +     " join strike_team_deployment_operational_period on (strike_team_deployment_operational_period.id=strike_team_deployment_assignment.operational_period_id)"
        +     " join vehicle on (vehicle.id=strike_team_deployment_assignment.vehicle_id)"
        +     " join service on (service.id=vehicle.service_id)"
        +     " join vehicle_kind on (vehicle_kind.id=vehicle.kind_id)"
        +     " join strike_team_deployment_vehicle on (strike_team_deployment_vehicle.deployment_id=strike_team_deployment_operational_period.deployment_id and strike_team_deployment_vehicle.vehicle_id=vehicle.id)"
        +     " join member on (member.id=strike_team_deployment_assignment.member_id)"
        +     " left join practitioner_level on (practitioner_level.id=member.level_id)"
        +     " join patient_care_level on (patient_care_level.id=vehicle.patient_care_level_id)"
        +     " join practitioner_strike_team_detail on (practitioner_strike_team_detail.practitioner_id=member.id)"
        +     " left join sms_gateway on (sms_gateway.id=practitioner_strike_team_detail.phone_service_id)" // left join in case a practitioner makes it onto the list despite becoming uncredentialed
        +   " where strike_team_deployment_operational_period.deployment_id = '" + deployment_id + "'"
        +   " order by " + sort_order.Replace("%",(be_sort_order_ascending ? " asc" : " desc")) + ",practitioner_level.pecking_order desc"
        +   " )"
        +   " as assignments"
        + " group by operational_period_id,vehicle_id"
        ,
        connection
        );
      ((target) as BaseDataList).DataSource = my_sql_command.ExecuteReader();
      ((target) as BaseDataList).DataBind();
      Close();
      }

    internal void BindDigestByOperationalPeriod
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string operational_period_id
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "select *"
        + " , count(member_id) as par"
        +   " , '?' as effective_patient_care_level"
        +   " , GROUP_CONCAT(strike_team_member_sms_target SEPARATOR ', ') as sms_target"
        + " from"
        +   " ("
        +   " select vehicle.id as vehicle_id"
        +   " , @static_designator := concat(service.short_name,' ',vehicle.name)"
        +   " , @dynamic_designator := IF(IFNULL(tactical_name = @static_designator,TRUE),@static_designator,concat(IFNULL(tactical_name,''),' [',@static_designator,']'))"
        +   " , IFNULL(@dynamic_designator,'(none)') as vehicle_designator"
        +   " , vehicle_kind.description as kind"
        +   " , patient_care_level.description as vehicle_patient_care_level_description"
        +   " , member_id"
        +   " , IFNULL(practitioner_level.short_description,'nocert') as max_practitioner_level_short_description"
        +   " , concat(phone_number,'@',hostname) as strike_team_member_sms_target"
        +   " , IFNULL(vehicle.elaboration,'') as elaboration"
        +   " , concat(member.last_name,', ',member.first_name) as leader"
        +   " , IFNULL(practitioner_level.pecking_order,'') as practitioner_level_pecking_order"
        +   " , IFNULL(member.certification_number,'nocert') as practitioner_certification_number"
        +   " , practitioner_strike_team_detail.phone_number as leader_phone_num"
        +   " from strike_team_deployment_assignment"
        +     " join strike_team_deployment_operational_period on (strike_team_deployment_operational_period.id=strike_team_deployment_assignment.operational_period_id)"
        +     " join vehicle on (vehicle.id=strike_team_deployment_assignment.vehicle_id)"
        +     " join service on (service.id=vehicle.service_id)"
        +     " join vehicle_kind on (vehicle_kind.id=vehicle.kind_id)"
        +     " join strike_team_deployment_vehicle on (strike_team_deployment_vehicle.deployment_id=strike_team_deployment_operational_period.deployment_id and strike_team_deployment_vehicle.vehicle_id=vehicle.id)"
        +     " join member on (member.id=strike_team_deployment_assignment.member_id)"
        +     " left join practitioner_level on (practitioner_level.id=member.level_id)"
        +     " join patient_care_level on (patient_care_level.id=vehicle.patient_care_level_id)"
        +     " join practitioner_strike_team_detail on (practitioner_strike_team_detail.practitioner_id=member.id)"
        +     " left join sms_gateway on (sms_gateway.id=practitioner_strike_team_detail.phone_service_id)" // left join in case a practitioner makes it onto the list despite becoming uncredentialed
        +   " where operational_period_id = '" + operational_period_id + "'"
        +   " order by practitioner_level_pecking_order desc, practitioner_certification_number"
        +   " )"
        +   " as assignments"
        + " group by vehicle_id"
        + " order by " + sort_order.Replace("%",(be_sort_order_ascending ? " asc" : " desc"))
        ,
        connection
        );
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
        + " , CONVERT(concat(id) USING utf8) as spec"
        + " FROM strike_team_deployment_assignment"
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

    public void BindOpfarByMemberByOperationalPeriod
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string operational_period_id,
      string assignment_level_filter
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "select @static_designator := concat(service.short_name,' ',vehicle.name)"
        + " , @dynamic_designator := IF(IFNULL(tactical_name = @static_designator,TRUE),concat(@static_designator,' (',vehicle_kind.description,')'),concat(IFNULL(tactical_name,''),' [',@static_designator,' (',vehicle_kind.description,')]'))"
        + " , IFNULL(@dynamic_designator,'(none)') as vehicle_designator"
        + " , concat(member.last_name,', ',member.first_name,' (',IFNULL(practitioner_level.short_description,'nocert'),' ',IFNULL(member.certification_number,'nocert'),')') as member_designator"
        + " , member_id"
        + " , phone_number as member_phone_num"
        + " from strike_team_deployment_assignment"
        +   " join strike_team_deployment_operational_period on (strike_team_deployment_operational_period.id=strike_team_deployment_assignment.operational_period_id)"
        +   " left join vehicle on (vehicle.id=strike_team_deployment_assignment.vehicle_id)"
        +   " left join service on (service.id=vehicle.service_id)"
        +   " left join vehicle_kind on (vehicle_kind.id=vehicle.kind_id)"
        +   " left join strike_team_deployment_vehicle on (strike_team_deployment_vehicle.deployment_id=strike_team_deployment_operational_period.deployment_id and strike_team_deployment_vehicle.vehicle_id=vehicle.id)"
        +   " join member on (member.id=strike_team_deployment_assignment.member_id)"
        +   " left join practitioner_level on (practitioner_level.id=member.level_id)"
        +   " join practitioner_strike_team_detail on (practitioner_strike_team_detail.practitioner_id=member.id)"
        + " where operational_period_id = '" + operational_period_id + "'"
        +     (assignment_level_filter.Length == 0 ? k.EMPTY : " and vehicle.id is not null")
        + " order by " + sort_order.Replace("%",(be_sort_order_ascending ? " asc" : " desc")),
        connection
        );
      ((target) as BaseDataList).DataSource = my_sql_command.ExecuteReader();
      ((target) as BaseDataList).DataBind();
      Close();
      }

    internal void BindOpfarByVehicleByOperationalPeriod
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string operational_period_id
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "select *"
        + " , count(member_id) as par"
        +   " , '?' as effective_patient_care_level"
        +   " , GROUP_CONCAT(concat(leader,' (',max_practitioner_level_short_description,' ',practitioner_certification_number,')') SEPARATOR '<br/>') as crew"
        + " from"
        +   " ("
        +   " select vehicle.id as vehicle_id"
        +   " , @static_designator := concat(service.short_name,' ',vehicle.name)"
        +   " , @dynamic_designator := IF(IFNULL(tactical_name = @static_designator,TRUE),@static_designator,concat(IFNULL(tactical_name,''),' [',@static_designator,']'))"
        +   " , IFNULL(@dynamic_designator,'(none)') as vehicle_designator"
        +   " , vehicle_kind.description as kind"
        +   " , IFNULL(patient_care_level.description,'---') as vehicle_patient_care_level_description"
        +   " , member_id"
        +   " , IFNULL(practitioner_level.short_description,'nocert') as max_practitioner_level_short_description"
        +   " , concat(phone_number,'@',hostname) as strike_team_member_sms_target"
        +   " , IFNULL(vehicle.elaboration,'') as elaboration"
        +   " , concat(member.last_name,', ',member.first_name) as leader"
        +   " , IFNULL(practitioner_level.pecking_order,'') as practitioner_level_pecking_order"
        +   " , IFNULL(member.certification_number,'nocert') as practitioner_certification_number"
        +   " , practitioner_strike_team_detail.phone_number as leader_phone_num"
        +   " from strike_team_deployment_assignment"
        +     " join strike_team_deployment_operational_period on (strike_team_deployment_operational_period.id=strike_team_deployment_assignment.operational_period_id)"
        +     " left join vehicle on (vehicle.id=strike_team_deployment_assignment.vehicle_id)"
        +     " left join service on (service.id=vehicle.service_id)"
        +     " left join vehicle_kind on (vehicle_kind.id=vehicle.kind_id)"
        +     " left join strike_team_deployment_vehicle on (strike_team_deployment_vehicle.deployment_id=strike_team_deployment_operational_period.deployment_id and strike_team_deployment_vehicle.vehicle_id=vehicle.id)"
        +     " join member on (member.id=strike_team_deployment_assignment.member_id)"
        +     " left join practitioner_level on (practitioner_level.id=member.level_id)"
        +     " left join patient_care_level on (patient_care_level.id=vehicle.patient_care_level_id)"
        +     " join practitioner_strike_team_detail on (practitioner_strike_team_detail.practitioner_id=member.id)"
        +     " left join sms_gateway on (sms_gateway.id=practitioner_strike_team_detail.phone_service_id)" // left join in case a practitioner makes it onto the list despite becoming uncredentialed
        +   " where operational_period_id = '" + operational_period_id + "'"
        +   " order by practitioner_level_pecking_order desc, practitioner_certification_number"
        +   " )"
        +   " as assignments"
        + " group by vehicle_id"
        + " order by " + sort_order.Replace("%",(be_sort_order_ascending ? " asc" : " desc"))
        ,
        connection
        );
      ((target) as BaseDataList).DataSource = my_sql_command.ExecuteReader();
      ((target) as BaseDataList).DataBind();
      Close();
      }

    public bool Delete(string id)
      {
      var result = true;
      Open();
      try
        {
        using var my_sql_command = new MySqlCommand(db_trail.Saved("delete from strike_team_deployment_assignment where id = \"" + id + "\""), connection);
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
      out string operational_period_id,
      out string member_id,
      out string vehicle_id
      )
      {
      operational_period_id = k.EMPTY;
      member_id = k.EMPTY;
      vehicle_id = k.EMPTY;
      var result = false;
      //
      Open();
      using var my_sql_command = new MySqlCommand("select * from strike_team_deployment_assignment where CAST(id AS CHAR) = \"" + id + "\"", connection);
      var dr = my_sql_command.ExecuteReader();
      if (dr.Read())
        {
        operational_period_id = dr["operational_period_id"].ToString();
        member_id = dr["member_id"].ToString();
        vehicle_id = dr["vehicle_id"].ToString();
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    public void Save
      (
      string operational_period_id,
      string member_id,
      string vehicle_id,
      bool be_assigned
      )
      {
      Open();
      if (be_assigned)
        {
        using var my_sql_command = new MySqlCommand
          (db_trail.Saved("insert ignore strike_team_deployment_assignment set operational_period_id = '" + operational_period_id + "', member_id = '" + member_id + "', vehicle_id = '" + vehicle_id + "'"), connection)
          ;
        my_sql_command.ExecuteNonQuery();
        }
      else
        {
        using var my_sql_command = new MySqlCommand
          (db_trail.Saved("delete from strike_team_deployment_assignment where operational_period_id = '" + operational_period_id + "' and member_id = '" + member_id + "' and vehicle_id = '" + vehicle_id + "'"), connection)
          ;
        my_sql_command.ExecuteNonQuery();
        }
      Close();
      }

    public void Set
      (
      string id,
      string operational_period_id,
      string member_id,
      string vehicle_id
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "operational_period_id = NULLIF('" + operational_period_id + "','')"
      + " , member_id = NULLIF('" + member_id + "','')"
      + " , vehicle_id = NULLIF('" + vehicle_id + "','')"
      + k.EMPTY;
      db_trail.MimicTraditionalInsertOnDuplicateKeyUpdate
        (
        target_table_name:"strike_team_deployment_assignment",
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
        "SELECT *"
        + " FROM strike_team_deployment_assignment"
        + " where id = '" + id + "'",
        connection
        );
      var dr = my_sql_command.ExecuteReader();
      dr.Read();
      var the_summary = new strike_team_deployment_assignment_summary()
        {
        id = id
        };
      Close();
      return the_summary;
      }

    } // end TClass_db_strike_team_deployment_assignments

  }
