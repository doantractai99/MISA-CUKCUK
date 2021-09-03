<template>
  <tbody>
    <tr
      v-on:dblclick="showDialog(employee.employeeId)"
      v-for="employee in employees"
      :key="employee.employeeId"
    >
      <td><input class="selected" type="checkbox" /></td>
      <td>{{ employee.employeeCode }}</td>
      <td>{{ employee.fullName }}</td>
      <td>{{ formatGenderName(employee.gender) }}</td>
      <td class="text-align-center">
        {{ formatDateDMY(employee.dateOfBirth) }}
      </td>
      <td>{{ employee.identityNumber }}</td>
      <td>
        <div class="text-inline-description width-position">
          {{ employee.positionName }}
        </div>
      </td>
      <td>
        <div class="text-inline-description width-department">
          {{ employee.departmentName }}
        </div>
      </td>
      <td>{{ employee.bankNumber }}</td>
      <td>{{ employee.bankName }}</td>
      <td>
        <div class="text-inline-description width-branch">
          {{ employee.branch }}
        </div>
      </td>
      <td
        v-on:click="showDialog(employee.employeeId)"
        class="text-align-center click-edit"
      >
        Sửa
      </td>
    </tr>
  </tbody>
</template>
<script>
import axios from "axios";
import { CommonFn } from "../../js/mixins.js";
export default {
  mixins: [CommonFn],
  name: "EmployeeList",
  data() {
    return {
      employees: null,
    };
  },
  props: {
    isHidden: {
      type: Boolean,
      default: true,
    },
    btnType: {
      type: Number,
      default: 0,
    },
  },
  methods: {
    showDialog(EmployeeId) {
      var data = {
        isHidden: false,
        EmployeeId: EmployeeId,
        btnType: 2,
      };
      this.$emit("changeEvent", data);
    },
  },
  created() {
    axios.get("https://localhost:44311/api/Employees").then((response) => {
      this.employees = response.data;
    });
  },
  watch: {
    btnType() {
      if (this.btnType === 3) {
        axios.get("https://localhost:44311/api/Employees").then((response) => {
          this.employees = response.data;
        });
      }
    },
  },
};
</script>
<style scoped>
</style>
