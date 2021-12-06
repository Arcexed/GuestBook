<template>
    <header>
        <nav class="nav">
            <div class="container">
                <div class="nav__inner">
                  <router-link class="navbar-brand" to="/">GuestBook</router-link>
<!--                  <button class="navbar-toggler"
                          type="button"
                          data-toggle="collapse"
                          data-target=".navbar-collapse"
                          aria-label="Toggle navigation"
                          @click="toggle">
                    <span class="navbar-toggler-icon"></span>
                  </button>-->
                  <div class=""
                       v-bind:class="{show: isExpanded}">
                    <ul class="nav-items">
                      <li class="nav-item">
                        <router-link :to="{ name: 'Notes' }" class="nav-link text-dark">Leave note</router-link>
                      </li>
                    </ul>
                  </div>
                </div>
            </div>
        </nav>
    </header>
</template>


<style scoped>
.nav {
 
  
}
.nav__inner{
  margin-top: 20px;
  display: flex;
  justify-content: space-between;
}
.navbar-brand{
  font-size: 25px;
  font-weight: 700;
}
.nav-items{
  display: flex;
}
.nav-item{
  display: flex;
}
</style>
<script>
    export default {
        name: "NavMenu",
        data() {
            return {
                isExpanded: false
            }
        },
        methods: {
            collapse() {
                this.isExpanded = false;
            },

            toggle() {
                this.isExpanded = !this.isExpanded;
            }
        }
    }
</script>