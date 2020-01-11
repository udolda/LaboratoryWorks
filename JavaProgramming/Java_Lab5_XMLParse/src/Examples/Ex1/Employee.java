package Examples.Ex1;

public class Employee {
        private String name;
        private String job;
        public Employee(){
            name = "--";
            job = "--";
        }
        public Employee(String name, String job){
            this.name = name;
            this.job = job;
        }
        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public String getJob() {
            return job;
        }

        public void setJob(String job) {
            this.job = job;
        }

    @Override
    public String toString() {
        return String.format("Name: %s \n\tJob: %s",name,job);
    }
}
