<template>
  <div>
    <h1>新增月營收項目</h1>
    <form @submit.prevent="addRevenueItem" class="form">
  <div class="form-row">
    <span class="form-label">報告日期：</span>
    <input type="text" v-model="reportDate" required />
  </div>

  <div class="form-row">
    <span class="form-label">年月：</span>
    <input type="text" v-model="dataYM" required />
  </div>

  <div class="form-row">
    <span class="form-label">公司代號：</span>
    <input type="text" v-model="companyCode" required />
  </div>

  <div class="form-row">
    <span class="form-label">公司名稱：</span>
    <input type="text" v-model="companyName" required />
  </div>

  <div class="form-row">
    <span class="form-label">產業：</span>
    <input type="text" v-model="industry" required />
  </div>

  <div class="form-row">
    <span class="form-label">本月營收：</span>
    <input type="number" v-model.number="nowRevenue" required />
  </div>

  <div class="form-row">
    <span class="form-label">上月營收：</span>
    <input type="number" v-model.number="lastMonthRevenue" required />
  </div>

  <div class="form-row">
    <span class="form-label">去年同月營收：</span>
    <input type="number" v-model.number="lastYearSameMonthRevenue" required />
  </div>

  <div class="form-row">
    <span class="form-label">月營收變動百分比：</span>
    <input type="text" v-model="monthlyPercentInput" inputmode="decimal"/>
  </div>

  <div class="form-row">
    <span class="form-label">年營收變動百分比：</span>
    <input type="text" v-model="yearlyPercentInput" inputmode="decimal"/>
  </div>

  <div class="form-row">
    <span class="form-label">當月累計營收：</span>
    <input type="number" v-model.number="CumulativeNowRevenue" required />
  </div>

  <div class="form-row">
    <span class="form-label">去年累計營收：</span>
    <input type="number" v-model.number="cumulativeLastYearRevenue" required />
  </div>

  <div class="form-row">
    <span class="form-label">累計營收變動百分比：</span>
    <input type="text" v-model="cumulativeChangePercentInput" inputmode="decimal"/>
  </div>

  <div class="form-row">
    <span class="form-label">備註：</span>
    <textarea v-model="comment"></textarea>
  </div>

  <div class="button-row">
    <button type="button" @click="$router.go(-1)">回上一頁</button>
    <button type="submit">新增</button>
  </div>
</form>

  </div>
</template>

<script>
import * as api from '../services/api';

export default {
  data() {
    return {
      reportDate: '',
      dataYM: '',
      companyCode: '',
      companyName: '',
      industry: '',
      nowRevenue: 0,
      lastMonthRevenue: 0,
      lastYearSameMonthRevenue: 0,
      monthlyPercentInput: '',
      monthlyPercent: null,
      yearlyPercentInput: '',
      yearlyPercent: null,
      CumulativeNowRevenue: 0,
      cumulativeLastYearRevenue: 0,
      cumulativeChangePercentInput: '',
      cumulativeChangePercent: null,
      comment: ''
    };
  },
  watch: {
    monthlyPercentInput(val) {
      const num = Number(val);
      this.monthlyPercent = isNaN(num) ? null : num;
    },
    yearlyPercentInput(val) {
      const num = Number(val);
      this.yearlyPercent = isNaN(num) ? null : num;
    },
    cumulativeChangePercentInput(val) {
      const num = Number(val);
      this.cumulativeChangePercent = isNaN(num) ? null : num;
    }
  },
  methods: {
    async addRevenueItem() {
      try {
        const newItem = {
          reportDate: this.reportDate,
          dataYM: this.dataYM,
          companyCode: this.companyCode,
          companyName: this.companyName,
          industry: this.industry,
          nowRevenue: this.nowRevenue,
          lastMonthRevenue: this.lastMonthRevenue,
          lastYearSameMonthRevenue: this.lastYearSameMonthRevenue,
          monthlyPercent: this.monthlyPercent,
          yearlyPercent: this.yearlyPercent,
          CumulativeNowRevenue: this.CumulativeNowRevenue,
          cumulativeLastYearRevenue: this.cumulativeLastYearRevenue,
          cumulativeChangePercent: this.cumulativeChangePercent,
          comment: this.comment
        };
        await api.addMonthlyRevenue(newItem);
        this.$router.push({ name: 'View' });
        alert('新增成功！');
        this.resetForm();
      } catch (error) {
        console.error('新增失敗，錯誤為:', error);
        alert('新增失敗。');
      }
    },
    resetForm() {
      this.reportDate = '';
      this.dataYM = '';
      this.companyCode = '';
      this.companyName = '';
      this.industry = '';
      this.nowRevenue = 0;
      this.lastMonthRevenue = 0;
      this.lastYearSameMonthRevenue = 0;
      this.monthlyPercent = null;
      this.yearlyPercent = null;
      this.CumulativeNowRevenue = 0;
      this.cumulativeLastYearRevenue = 0;
      this.cumulativeChangePercent = null;
      this.comment = '';
    },
    formatTwoDecimal(field) { 
      if (this[field] === null || this[field] === '') return;

      const value = Number(this[field]);
      if (isNaN(value)) return;

      this[field] = value.toFixed(15);
    }
  }
};
</script>

<style scoped>
h1 {
  font-size: 1.5em;
  margin-bottom: 20px;
}
form {
  display: flex;
  flex-direction: column;
}
label {
  margin-bottom: 10px;
}
input[type="text"], input[type="number"], textarea {
  padding: 5px;
  font-size: 1em;
  margin-top: 5px;
}
button {
  margin-top: 20px;
  padding: 10px;
  font-size: 1em;
  cursor: pointer;
}

.form {
  max-width: 700px;
  margin: 0 auto;
}

.form-row {
  display: flex;
  align-items: center;
  margin-bottom: 12px;
}

.form-label {
  width: 180px;
  text-align: right;
  margin-right: 10px;
  font-weight: 500;
}

.form-row input,
.form-row textarea {
  flex: 1;
  padding: 6px 8px;
  font-size: 1em;
}

.form-row textarea {
  min-height: 80px;
}

.button-row {
  display: flex;
  justify-content: center;
  gap: 10px;
  margin-top: 20px;
}
</style>
