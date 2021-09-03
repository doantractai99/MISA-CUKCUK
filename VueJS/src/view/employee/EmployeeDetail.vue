<template>
  <div class="dailog" :class="{ isHidden: isHidden }">
    <div class="popup-black"></div>
    <div class="popup">
      <div class="popup-header">
        <div class="popup-title">Thông tin nhân viên</div>
        <div class="popup-close">
          <div class="popup-icon-support"></div>
          <div v-on:click="cancelDialog" class="popup-icon-close"></div>
        </div>
      </div>
      <div class="popup-content">
        <div class="popup-t">
          <div class="popup-l-t">
            <div class="popup-lr flex">
              <div class="textbox-code pad-6">
                <div class="lable-code blod">
                  Mã<span class="cl-red"> *</span>
                </div>
                <div class="input-code">
                  <input
                    v-on:blur="fieldRequied"
                    v-model="employee.employeeCode"
                    type="text"
                    id="code"
                    class="text-box-default"
                    style="width: 151px"
                  />
                </div>
              </div>
              <div class="textbox-employee-name">
                <div class="lable-employee-name blod">
                  Tên<span class="cl-red"> *</span>
                </div>
                <div class="input-employee-name">
                  <input
                    v-on:blur="fieldRequied"
                    v-model="employee.fullName"
                    id="employeeName"
                    type="text"
                    class="text-box-default"
                    style="width: 235px"
                  />
                </div>
              </div>
            </div>
            <div class="popup-lr">
              <div class="row">
                <div class="combobox-name blod">
                  Đơn vị<span class="cl-red"> *</span>
                </div>
                <div class="combobox">
                  <input
                    v-on:blur="fieldRequied"
                    v-model="departmentName"
                    class="combobox-department"
                    id="departmentName"
                    type="text"
                    name=""
                  />
                  <button class="btn-combobox" v-on:click="showCombobox">
                    <div class="btn-icon"></div>
                  </button>
                  <div class="combobox-data">
                    <div
                      v-on:click="slectedDepartment"
                      v-for="department in departments"
                      :key="department.departmentId"
                      v-bind:value="department.departmentId"
                      class="combobox-item"
                    >
                      {{ department.departmentName }}
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="popup-lr">
              <div class="lable-position blod">Chức danh</div>
              <div class="input-position">
                <input
                  v-model="employee.positionName"
                  type="text"
                  class="text-box-default"
                  style="width: 100%"
                />
              </div>
            </div>
          </div>
          <div class="popup-r-t">
            <div class="popup-rr flex">
              <div class="textbox-dob pad-6">
                <div class="lable-dob blod">Ngày sinh</div>
                <div class="input-dob">
                  <input
                    v-model="formatDateOfBirth"
                    type="date"
                    class="text-box-default width-textbox-code"
                  />
                </div>
              </div>
              <div class="textbox-gender">
                <div class="lable-position blod">Giới tính</div>
                <div class="radio-gender">
                  <input
                    type="radio"
                    id="1"
                    name="gender"
                    value="1"
                    v-on:click="selectGender"
                  /><label for="nam">Nam</label><br />
                  <input
                    type="radio"
                    id="0"
                    name="gender"
                    value="0"
                    v-on:click="selectGender"
                  /><label for="nu">Nữ</label><br />
                  <input
                    type="radio"
                    id="2"
                    name="gender"
                    value="2"
                    v-on:click="selectGender"
                  /><label for="khac">Khác</label>
                </div>
              </div>
            </div>
            <div class="popup-rr flex">
              <div class="textbox-identityNumber pad-6">
                <div class="lable-identityNumber blod">Số CMND</div>
                <div class="input-identityNumber">
                  <input
                    v-model="employee.identityNumber"
                    type="text"
                    class="text-box-default"
                    style="width: 245px"
                  />
                </div>
              </div>
              <div class="textbox-identityDate">
                <div class="lable-dob blod">Ngày cấp</div>
                <div class="input-code">
                  <input
                    v-model="formatIdentityDate"
                    type="date"
                    class="text-box-default"
                    style="width: 167px"
                  />
                </div>
              </div>
            </div>
            <div class="popup-rr">
              <div class="textbox-identityPlace">
                <div class="lable-identityPlace blod">Nơi cấp</div>
                <div class="input-identityPlace">
                  <input
                    v-model="employee.identityPlace"
                    type="text"
                    class="text-box-default"
                    style="width: 100%"
                  />
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="popup-b">
          <div class="popup-br">
            <div class="textbox-address">
              <div class="lable-address blod">Địa chỉ</div>
              <div class="input-address">
                <input
                  v-model="employee.address"
                  type="text"
                  class="text-box-default"
                  style="width: 100%"
                />
              </div>
            </div>
          </div>
          <div class="popup-br flex">
            <div class="textbox-address pad-6">
              <div class="lable-address blod">ĐT di dộng</div>
              <div class="input-address">
                <input
                  v-model="employee.phoneNumber"
                  type="text"
                  class="text-box-default"
                  style="width: 100%"
                />
              </div>
            </div>
            <div class="textbox-address pad-6">
              <div class="lable-address blod">ĐT cố định</div>
              <div class="input-address">
                <input
                  v-model="employee.landlinNumber"
                  type="text"
                  class="text-box-default"
                  style="width: 100%"
                />
              </div>
            </div>
            <div class="textbox-address">
              <div class="lable-address blod">Email</div>
              <div class="input-address">
                <input
                  v-model="employee.email"
                  type="text"
                  id="email"
                  class="text-box-default"
                  style="width: 100%"
                />
              </div>
            </div>
          </div>
          <div class="popup-br flex">
            <div class="textbox-address pad-6">
              <div class="lable-address blod">Tài khoản ngân hàng</div>
              <div class="input-address">
                <input
                  v-model="employee.bankNumber"
                  type="text"
                  class="text-box-default"
                  style="width: 100%"
                />
              </div>
            </div>
            <div class="textbox-address pad-6">
              <div class="lable-address blod">Tên ngân hàng</div>
              <div class="input-address">
                <input
                  v-model="employee.bankName"
                  type="text"
                  class="text-box-default"
                  style="width: 100%"
                />
              </div>
            </div>
            <div class="textbox-address">
              <div class="lable-address blod">Chi nhánh</div>
              <div class="input-address">
                <input
                  v-model="employee.branch"
                  type="text"
                  class="text-box-default"
                  style="width: 100%"
                />
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="popup-footer">
        <div class="divide"></div>
        <div class="btn">
          <div class="footer-left">
            <div v-on:click="cancelDialog" class="btn-cancel">Hủy</div>
          </div>
          <div class="footer-rigth">
            <div v-on:click="btnSave" class="btn-save">Cất</div>
            <div class="button btn-save-add">Cất và Thêm</div>
          </div>
        </div>
      </div>

      <ToastMessage
        :isHidden="isHiddenToast"
        :messageContent="messageContent"
        :iconMessage="iconMessage"
        v-on:changeEvent="handleShowToast"
      />
    </div>
  </div>
</template>
<script>
import axios from "axios";
import $ from "jquery";
import ToastMessage from "../../components/base/BaseToastMessage.vue";
import { CommonFn } from "../../js/mixins.js";

export default {
  mixins: [CommonFn],
  name: "EmployeeDetail",
  components: {
    ToastMessage,
  },
  props: {
    isHidden: Boolean,
    btnType: {
      type: Number,
      default: 0,
    },
    EmployeeId: {
      type: String,
      default: "",
    },
  },
  data() {
    return {
      isHiddenToast: true,
      employee: {},
      departments: null,
      formatDateOfBirth: "",
      formatIdentityDate: "",
      messageContent: "",
      iconMessage: "",
      departmentName: "",
    };
  },
  methods: {
    refreshValue() {
      this.employee = {};
      this.formatDateOfBirth = "";
      this.formatIdentityDate = "";
      this.departmentName = "";
    },
    cancelDialog() {
      this.refreshValue();
      var data = {
        isHidden: true,
      };
      this.$emit("changeEvent", data);
    },
    handleShowToast(e) {
      this.isHiddenToast = e.isHiddenToast;
      this.cancelDialog();
      this.loadData();
    },
    showCombobox() {
      var check = $(".combobox-data").css("display");
      if (check === "block") {
        $(".combobox-data").hide();
      } else $(".combobox-data").show();
    },

    slectedDepartment(e) {
      this.employee.departmentId = $(e.target).attr("value");
      this.departmentName = $(e.target).text();
      $("#departmentName").val($(e.target).text());
      $(".combobox-department").removeClass("missing");
      $(".combobox-data").hide();
    },
    selectGender(e) {
      this.employee.gender = $(e.target).attr("value");
    },
    fieldRequied(e) {
      let ip = $(e.target).val();
      if (ip == "") {
        //Đổi trạng thái lỗi input
        $(e.target).addClass("missing");
      } else {
        $(e.target).removeClass("missing");
      }
    },
    loadData() {
      var data = {
        btnType: 3,
      };
      this.$emit("loadData", data);
    },
    btnSave() {
      let me = this;
      // Cảnh báo trường mã nhân viên trống
      if ($("#code").val() === "") {
        me.iconMessage = "icon-warring";
        me.messageContent = "Mã nhâ viên không được để trống";
        me.isHiddenToast = false;
      }
      // Cảnh bảo trường tên nhân viên trống
      else if ($("#employeeName").val() === "") {
        me.iconMessage = "icon-warring";
        me.messageContent = "Tên nhân viên không được để trống";
        me.isHiddenToast = false;
      }
      // Cảnh bảo trường đơn vị trống
      else if ($("#departmentName").val() === "") {
        me.iconMessage = "icon-warring";
        me.messageContent = "Đơn vị không được để trống";
        me.isHiddenToast = false;
      } else if (!me.validEmail($("#email").val())) {
        me.iconMessage = "icon-warring";
        me.messageContent = "Email sai định dạng";
        me.isHiddenToast = false;
      } else {
        if (this.btnType === 2) {
          this.employee.dateOfBirth = this.formatDateOfBirth;
          this.employee.identityDate = this.formatIdentityDate;
          console.log(this.employee);
          axios
            .put(
              "https://localhost:44311/api/Employees/" + this.EmployeeId,
              this.employee
            )
            .then(function (res) {
              console.log(res);
              console.log(res.status);
              switch (res.status) {
                case 201: {
                  me.iconMessage = "icon-error";
                  me.messageContent = "Sửa thành công";
                  me.isHiddenToast = false;
                  break;
                }
              }
            })
            .catch(function (error) {
              switch (error.response.status) {
                case 400: {
                  me.iconMessage = "icon-warring";
                  me.messageContent = error.response.data;
                  me.isHiddenToast = false;
                  break;
                }
                case 500: {
                  me.iconMessage = "icon-warring";
                  me.messageContent = error.response.data;
                  me.isHiddenToast = false;
                  break;
                }
              }
            });
        } else if (this.btnType === 1) {
          console.log(this.employee);
          axios
            .post("https://localhost:44311/api/Employees", this.employee)
            .then(function (res) {
              switch (res.status) {
                case 201: {
                  me.iconMessage = "icon-error";
                  me.messageContent = "Thêm thành công";
                  me.isHiddenToast = false;
                  break;
                }
              }
            })
            .catch(function (error) {
              switch (error.response.status) {
                case 400: {
                  me.iconMessage = "icon-warring";
                  me.messageContent = error.response.data;
                  me.isHiddenToast = false;
                  break;
                }
                case 500: {
                  me.iconMessage = "icon-warring";
                  me.messageContent = error.response.data;
                  me.isHiddenToast = false;
                  break;
                }
              }
            });
        }
      }
    },
  },
  watch: {
    btnType() {
      if (this.btnType === 2) {
        axios
          .get("https://localhost:44311/api/Employees/" + this.EmployeeId)
          .then((response) => {
            this.employee = response.data.data;
            this.formatDateOfBirth = this.formatDateYMD(
              this.employee.dateOfBirth
            );
            this.formatIdentityDate = this.formatDateYMD(
              this.employee.identityDate
            );
            this.departmentName = this.employee.departmentName;
          });
      } else {
        axios
          .get("https://localhost:44311/api/Employees/NewEmployeeCode")
          .then((response) => {
            this.employee.employeeCode = response.data;
          });
      }
    },
  },
  created() {
    axios.get("https://localhost:44311/api/Departments").then((response) => {
      this.departments = response.data;
    });
  },
};
</script>
<style scoped>
</style>
