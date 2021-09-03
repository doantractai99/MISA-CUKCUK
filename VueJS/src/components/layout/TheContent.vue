<template>
  <div class="content">
    <div class="router-content">
      <div class="header-list">
        <div class="header-di">
          <div class="title-di"><b>Nhân viên</b></div>
        </div>
        <button class="button" v-on:click="addEmployee">
          Thêm mới nhân viên
        </button>
      </div>

      <div class="grid-content">
        <div class="grid-list-data">
          <div class="grid-left"></div>
          <div class="grid-right">
            <div class="textbox">
              <div class="textbox-icon icon-search"></div>
              <input
                class="text-box-default textbox-with-icon width-search"
                type="text"
                id="searchfield"
                placeholder="Tìm theo mã, tên nhân viên"
              />
            </div>
            <div class="icon-refresh"></div>
            <div class="icon-excel"></div>
          </div>
        </div>

        <div id="gridEmployee">
          <table class="table">
            <thead>
              <tr>
                <th><input class="selected" type="checkbox" /></th>
                <th>MÃ NHÂN VIÊN</th>
                <th>TÊN NHÂN VIÊN</th>
                <th>GIỚI TÍNH</th>
                <th class="text-align-center">NGÀY SINH</th>
                <th>SỐ CMND</th>
                <th>CHỨC DANH</th>
                <th>TÊN ĐƠN VỊ</th>
                <th>SỐ TÀI KHOẢN</th>
                <th>TÊN NGÂN HÀNG</th>
                <th>CHI NHÁNH TK NGÂN HÀNG</th>
                <th>CHỨC NĂNG</th>
              </tr>
            </thead>
            <EmployeeList
              v-bind:isHidden="isHidden"
              v-bind:btnType="btnType"
              v-on:changeEvent="handleShowDialog"
            />
          </table>
          <div class="footer">
            <div class="record-number">Tổng số: <b>1000</b> bản ghi</div>
            <div class="pages"></div>
          </div>
        </div>
      </div>
    </div>

    <EmployeeDetail
      :isHidden="isHidden"
      v-bind:EmployeeId='EmployeeId'
      v-bind:btnType="btnType"
      v-on:changeEvent="handleShowDialog"
      v-on:loadData='loadData'
    />
  </div>
</template>

<script>
import EmployeeList from "../../view/employee/EmployeeList.vue";
import EmployeeDetail from "../../view/employee/EmployeeDetail.vue";
export default {
  name: "Content",
  components: {
    EmployeeList,
    EmployeeDetail,
  },
  data() {
    return {
      isHidden: true,
      EmployeeId: '',
      btnType: 0,
    };
  },
  methods: {
    showAddForm() {
      this.isHidden = false;
      // this.formMode = 0;
      // this.toggleForm = !this.toggleForm;
    },
    handleShowDialog(e) {
      this.isHidden = e.isHidden;
      this.EmployeeId = e.EmployeeId;
      this.btnType = e.btnType;
    },
    addEmployee() {
      this.employee  = {};
      this.isHidden = false;
      this.btnType = 1;
    },
    editEmployee() {
      this.isHidden = false;
      this.btnType = 2;
    },
    loadData(e){
        this.btnType = e.btnType;
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
@import "../../css/layout/content.css";
</style>
