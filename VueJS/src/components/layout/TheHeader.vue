<template>
  <div class="header">
    <div class="header-left">
      <div class="toggle"></div>
      <div class="logo"></div>
    </div>
    <div class="header-right">
      <div class="company-selector">
        <div class="pointer"></div>
        <div class="company-name">
          <b>CÔNG TY TNHH SẢN XUẤT - THƯƠNG MẠI - DỊCH VỤ QUI PHÚC</b>
        </div>
        <div class="arrow"></div>
      </div>
      <div class="user">
        <div class="icon-bell"></div>
        <div class="user-avatar"></div>
        <div class="user-fullname"><b>Bùi Xuân Lộc</b></div>
        <div class="arrow"></div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Header",
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
@import "../../css/layout/header.css";
</style>
