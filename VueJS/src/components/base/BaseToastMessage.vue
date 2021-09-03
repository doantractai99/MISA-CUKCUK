<template>
  <div class="report" :class="{ isHidden: isHidden }">
    <div class="report-black"></div>
    <div class="toast-message">
      <div class="toast-content">
        <div :class="[iconMessage]"></div>
        <div class="message-content">{{messageContent}}</div>
      </div>
      <div class="mess-line"></div>
      <div class="footer-icon">
        <div
          class="button icon-close"
          v-on:click="closeToast"
          style="width: 76px"
        >
          Đóng
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "ToastMessage",
  props: {
    isHidden: Boolean,
    messageContent: String,
    iconMessage: String,
  },
  methods: {
    closeToast() {
      var data = {
        isHiddenToast: true,
      };
      this.$emit("changeEvent", data);
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
